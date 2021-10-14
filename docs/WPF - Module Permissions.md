# WPF Module Permissions

## Usage

1. Create a new module
2. Add role permission via class attribute.
   1. Sample: `[Roles("User,Admin")]`.

## Action Items

* [ ] Allow for multi-roles in Module. I.E. `[Roles("User,Admin")]`
* [ ] Minimize code in `RoleModuleInitializer` by inheriting the default and overriding the Initialize. This way we can clearly see our custom methods:
  * ModuleIsInUserRole
  * GetModuleRoles
  * GetCustomAttribute

## Prism Module Overview

Remember, Prism Modules should be universal and not know about the project referencing them. Modules can be reusable across multple projects.

For example, Loging pages.  

### Module Catalogs

When using a Module Catalog, you must register your modules in an `App.config`.

If your modules are outputting to a different directory (by default), you must then use the project's **Post-Build Events** to copy the `.dll` file(s) to the main project's output folder.

```sh
xcopy "$(TargetDir)Modules.Admin.dll" "$(SouldionDir)PrismRoles\Bin\$(ConfigurationName)\" /Y
```

In our example, all projects are being built in the `output` folder.

### Troubleshooting

If a module is not loading, double check the `App.config` file and ensure that the Module's entrypoint class is written out correctly. I.E. "FullNamespace.ClassName" - `Modules.Generic.GenericModule`.
