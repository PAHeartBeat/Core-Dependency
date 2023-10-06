# iPAHeartBeat Core Dependency

## Introduction
Introducing the Dependency Management Package

This package is designed to offer a fundamental dependency management system. It allows you to efficiently reuse various types or objects by maintaining just one instance of each. Think of it as a simplified form of a singleton system.

In simpler terms, this package helps you manage and share important pieces of code, making your programming tasks more efficient and organized. Whether you're a beginner or an experienced coder, it's a valuable tool for enhancing your projects.

For your convenience, we've included the following essential links:

- [Change Log](CHANGELOG.md)
- [UPM Package License](LICENCE.md)

## Unity Package

Our Unity Package is built on .NET Framework 4.71 and utilizes C# 10.

**Important Note**:

We've recently configured Unity Packages for easy accessibility through Cloud Smith IO. Now, anyone, including beginners, can integrate this package into their Unity projects effortlessly.

### How to Use

You can add this package to your Unity project in two ways, tailored for different preferences:

#### Using Unity Editor (Recommended for Beginners)

1. Open your project in the Unity Editor.
2. Access the Edit menu and select Project Settings.
3. Within the Project Settings window, navigate to the Package Manager section on the left.
4. Scroll down to the Scoped Registry section on the right.
5. In the left section, click the plus icon to create a new registry entry.
6. In the right section, fill in the following details:
   - **Name**: "C# Helper package by iPAHeartBeat"
   - **URL**: "https://npm.cloudsmith.io/ipaheartbeat/core"
   - **Scope(s)**: Click the plus icon and add `com.ipaheartbeat`.
7. Close the window and save your project from the File menu.
8. You're now all set to utilize the packages provided by us.

#### Modifying manifest.json (Advanced Option)

1. Open your project folder in Finder (on macOS) or Explorer (on Windows).
2. Locate the "Package" folder and open the `manifest.json` file in your preferred code or text editor (it's a JSON file).
3. Search for the `scopedRegistries` entry within the JSON file. If it's not present or empty, don't worry.
4. Add the following JSON data to the `scopedRegistries` array:

```json
{
	"name": "C# Helper package by iPAHeartBeat",
	"scopes": ["com.ipaheartbeat"],
	"url": "https://npm.cloudsmith.io/ipaheartbeat/core/"
}
```

5. Save the file and close it.
6. Open or reopen your Unity project.
7. You can now conveniently access our packages from the Unity Package Manager under the "My Registry" option.
