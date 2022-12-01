// --------------------------------------------------------------------------------
// <copyright file="DependencyResolver.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace iPAHeartBeat.Core.Dependency;

/// <summary>
/// This class will helper system to provide instance of the type to reuse, it's a kind of singleton system. but It might provides the options do variance implementation of the type by changing a single location.
/// </summary>
public static class DependencyResolver {
	/// <summary>
	/// Local collection of the the Types which are are registered without its instance.
	/// </summary>
	private static readonly Dictionary<Type, Type> _types = new Dictionary<Type, Type>();

	/// <summary>
	/// local Collection of the instance object of the type to reuse.
	/// </summary>
	private static readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

	/// <summary>
	/// The Service to register Type with it instance for re-use.
	/// </summary>
	/// <typeparam name="TType">The type, of which object requires re-uses.</typeparam>
	/// <typeparam name="TImplementation">The IImplementation of the type.</typeparam>
	public static void Register<TType, TImplementation>()
		where TImplementation : TType
		=> _types[typeof(TType)] = typeof(TImplementation);

	/// <summary>
	/// The Service to register Type with it instance for re-use.
	/// </summary>
	/// <typeparam name="TType">The type, of which object requires re-uses.</typeparam>
	public static void Register<TType>()
		=> Register<TType, TType>();

	/// <summary>
	/// The Service to register Type with it instance for re-use.
	/// </summary>
	/// <typeparam name="TType">The type, of which object requires re-uses.</typeparam>
	/// <param name="t">The instance value of the type as pre-defined to re-uses.</param>
	public static void Register<TType>(TType t)
		=> _instances[typeof(TType)] = t;

	/// <summary>
	/// The Service to get instance of the type to reuse.
	/// </summary>
	/// <typeparam name="T">The type, of which object requires re-uses.</typeparam>
	/// <returns>instance of the type.</returns>
	public static T Resolve<T>()
		=> (T)Resolve(typeof(T));

	/// <summary>
	/// The Service to remove type from the reuse via this system.
	/// </summary>
	/// <typeparam name="T">The Type which need to remove from re-use via the system.</typeparam>
	public static void Unregister<T>() {
		var t = typeof(T);
		if (_instances.ContainsKey(t)) {
			_ = _instances.Remove(t);
		}

		if (_types.ContainsKey(t)) {
			_ = _types.Remove(t);
		}
	}

	/// <summary>
	/// The local system which will find or identify which instance need to be return. this will create instate of the type if there are not instance present in the collection.
	/// </summary>
	/// <param name="type">The type for which we need to find instance object.</param>
	/// <returns>The Instance object of the type.</returns>
	private static object Resolve(Type type) {
		object instance = null;
		if (_instances.ContainsKey(type)) {
			instance = _instances[type];
		} else {
			if (_types.TryGetValue(type, out var value)) {
				var defaultConstructor = value.GetConstructors()[0];
				var defaultParams = defaultConstructor.GetParameters();
				var parameters = defaultParams.Select(param => Resolve(param.ParameterType)).ToArray();
				instance = defaultConstructor.Invoke(parameters);
				_instances[type] = instance;
			}
		}

		return instance;
	}
}
