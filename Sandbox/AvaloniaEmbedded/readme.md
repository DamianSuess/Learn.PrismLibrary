# Prism.Avalonia with Linux FrameBuffer and DRM

Linux FrameBuffer and DRM (Direct Rendering Manager) allows users to launch their applications via SSH or command line operations.

This sample project provides a test demonstration of these capabilities.

## Configuring WSL (Windows Subsystem Linux)

_Steps coming soon_

## Launching With WSL

Edit the `launchSettings.json` file to choose between FrameBuffer or DRM.

```json
{
  "profiles": {
    "SampleFrameBuffer.Desktop": {
      "commandName": "Project"
    },
    "WSL": {
      "commandName": "WSL2",
      // "commandLineArgs": "SampleFrameBuffer.Desktop.dll --fbdev",
      "commandLineArgs": "SampleFrameBuffer.Desktop.dll --drm",
      "distributionName": ""
    }
  }
}
```

## Basic Code Steps

_Coming Soon_
