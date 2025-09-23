## Bmob C# 示例项目
本仓库包含使用 Bmob C# SDK 的三个示例：Windows 桌面、Windows Phone 与 Unity。示例按模块演示常用能力：数据（`BmobDataForm`）、用户（`BmobUserForm`）、文件（`BmobFileUploadForm`）与云端代码（`BmobCloudCode`）。

## 目录结构
- `examples/bmob-desktop-demo`：Windows 桌面 WinForms 示例（.NET Framework 4.8）
- `examples/bmob-windowsphone-demo`：Windows Phone 8 示例
- `examples/bmob-unity-demo`：Unity 示例工程
- `docs/`：文档与图片资源（更多文档见 Wiki）

## 环境要求
- Windows 桌面示例：Visual Studio 2019/2022（或 VS 2012 及以上），.NET Framework 4.8（见 `examples/bmob-desktop-demo/App.config`）
- Windows Phone 示例：VS 2012/2013 + Windows Phone 8 SDK
- Unity 示例：Unity（建议 5.x 及以上版本）

## 快速开始
### Windows 桌面（WinForms）
1. 用 Visual Studio 打开 `examples/bmob-desktop-demo/HelloWindowsForm.sln`
2. 在 `Program.cs` 中按需选择要启动的窗体（数据/用户/文件/云端代码）
3. 运行并按照界面提示操作

### Windows Phone 8
1. 用 Visual Studio 打开 `examples/bmob-windowsphone-demo/HelloPhone.sln`
2. 配置 WP8 模拟器或真机调试，运行示例

### Unity
1. 用 Unity 打开 `examples/bmob-unity-demo`
2. 根据需要导入对应平台的插件，运行场景查看示例

## DLL 引用与用法
### DLL 位置
- Windows 桌面：`examples/bmob-desktop-demo/lib/Bmob-Windows.dll`（仓库根目录也提供 `Bmob-Windows.dll` 便于复用）
- Windows Phone：`examples/bmob-windowsphone-demo/lib/Bmob-WP8.dll`
- Unity：`examples/bmob-unity-demo/Assets/libs/Bmob-Unity.dll`

### 在 Visual Studio 中引用（Windows 桌面）
1. 在你的项目上右键 → “添加” → “引用...”
2. 选择“浏览”，定位到 `Bmob-Windows.dll` 并添加
3. 确认 `Copy Local` 为 `True`，平台目标设置为 `Any CPU` 或与项目一致

### 在 Unity 中引用
- 将 `Bmob-Unity.dll` 放置在 `Assets/Plugins/` 或保留于 `Assets/libs/`，Unity 会自动编译引用

### 初始化与最小示例（C#）
```csharp
using cn.bmob.api;
using cn.bmob.tools;

// 创建实例（桌面端）
var bmob = new BmobWindows();

// 用你的 ApplicationId 与 RestKey 初始化（登录 bmob 后台获取）
Bmob.initialize("Your_ApplicationId", "Your_RestKey");

// 可选：注册调试输出
BmobDebug.Register(msg => System.Diagnostics.Debug.WriteLine(msg));
```

进行数据读写示例（以查询为例）：
```csharp
using cn.bmob.io;

var query = new BmobQuery();
var result = await Bmob.FindTaskAsync<GameObject>("Game", query);
```

## 示例截图
仓库 `images/` 目录内包含数据、用户、文件上传与云端代码等界面截图，可配合示例运行效果参考。

## 文档
- 项目 Wiki（快速入门）：`https://github.com/bmob/bmob-demo-csharp/wiki/1-%E5%BF%AB%E9%80%9F%E5%85%A5%E9%97%A8`
- 桌面示例内置说明：`examples/bmob-desktop-demo/README.MD`

## 官方信息与支持
- 官方网站：`http://www.bmobapp.com`
- 技术支持邮箱：`support@bmob.cn`
- 工单支持：后台提交工单（工作日内反馈）

如需在示例基础上二次开发，建议先跑通桌面示例，再对照 Wiki 查看 API 用法与最佳实践。