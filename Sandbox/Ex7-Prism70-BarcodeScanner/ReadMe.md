# Example using Prism.Forms with Barcode Scanner

This is an example using Prism Barcode scanner with Prism.Forms and a but of other goodies.

### What In The Box?!
This project was created using the Prism QuickStart Templates.

It contains:
* Prism Barcode Scanner
* Prism.Forms
* Xamarin.Forms
* i18n - internationalization
* Splash screen with delayed loading spinner


## Developer Notes

This Project uses Mobile.BuildTools to inject sensitive variables at build time.
After cloning this repository you will need to make sure that you have taken some
time to do some basic setup in your environment prior to building.

### Application Secrets

Every application contains sensitive information that should never be checked into
source control. In order to handle this the Mobile.BuildTools looks for a file in
the project named `secrets.json`. If the file exists it will generate a new file
`Helpers/Secrets.cs` with the values from your json file. Be sure to update this ReadMe
with any Key values that get added over time so that other developers can add this
for local builds.

```json
{
  "AppCenter_iOS_Secret": "{App Center Secret}",
  "AppCenter_Android_Secret": "{App Center Secret}",
  "AppServiceEndpoint": "{Backend API URI}"
}
```

#### Build Server Secrets

Because `secrets.json` does not exist within the checked in code and `Helpers/Secrets.cs`
is also not checked in, the Build Server must generate the `secrets.json` as part of the
build. This is done automatically by including prefixed Environmental variables in the
build. For instance the secret for `AppCenter_iOS_Secret` would be added as
`Secret_AppCenter_iOS_Secret` to the build environment. You can additionally add
platform specific secrets that are not compiled as part of the shared code by using
the following Prefix Matrix:

| Platform | Secrets Prefix |
| -------- | -------------- |
| Android | DroidSecret_ |
| iOS | iOSSecret_ |
| UWP | UWPSecret_ |
| macOS | MacSecret_ |
| Tizen | TizenSecret_ |
| Default | Secret_ |

If you need to inject secrets into multiple shared libraries that are part of the same
solution you can do this by adding an override value for `BuildHostSecretPrefix` in
the PropertyGroup of your CSProj like:

```xml
<Project>
  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <BuildHostSecretPrefix>MyCustomPrefix_</BuildHostSecretPrefix>
  </PropertyGroup>
</Project>
```

### Application Manifests

The Mobile.BuildTools also helps with protecting Application Secrets that may be
contained within Application Manifests like `AndroidManifest.xml` or `Info.plist`.
Contained within the build directory are templates for these manifests which are
not checked into Source Control.

#### Developer Setup

The Manifest templates should be copied from the build directory to the appropriate
platform project and any placeholders updated as needed. Be sure that any changes
in app permissions, etc that you may make to the manifest are updated in the Template
as well. New secrets can be added to the template by adding `$$variableName$$` to
the template manifest. This will then be replaced automatically on the build server.

#### Build Server Setup

Any variables that may exist within the Manifest templates can be injected via a
token replacement. By default the Build Task will look for `$$` before and after
the variable name that you wish to replace. The build task will use any environment
variables that start with `Manifest_` to help facilitate token replacement.

For example, you may add `Manifest_AADClientId` to the build environment, and have
`$$AADClientId$$` as a token within your manifest. The Mobile.BuildTools by default
will only copy Manifests when building a Platform target such as iOS, Android, UWP.
If the build definition builds more than one platform target, any variables that
should be different from one platform to the next should use platform specific
tokens within the manifest.