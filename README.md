# SLS4All Compact all-in-one SLS 3D printing software

## Introduction
This software is part of SLS4All project. For more information please visit https://sls4all.com.

## Copying
*SLS4All Compact* source code and binaries are available under the terms of the 
License Agreement as described in the LICENSE.txt file located 
in the root directory of the repository or visit 
https://sls4all.com/terms-of-use/.

>##### In very short non-binding terms:
>You can use, copy, modify, and convey the software for **non-commercial** purposes **only**.
You can share modified versions of the software as long as you retain original notices, license 
and provide access to the modified source.
>
>We are not responsible for any damages, injuries, etc. caused in connection with the software. By exercising any right granted under the License, you irrevocably accept all its terms and conditions.

## NuGet packages
SLS4尚未开源的部件的所有 NuGet 包都发布在 GitHub 包源上。
这些 NuGet 包是从此存储库中存在的项目中引用的。
NuGet 包源的路径为 https://nuget.pkg.github.com/sls4all/index.json.
此源应已在此存储库根目录的 nuget.config 中配置。
请注意，GitHub [目前需要](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#authenticating-with-a-personal-access-token) 
已注册的 GitHub 帐户和关联的令牌才能下载 NuGet 包，即使包标记为公共也是如此。 

GitHub package source has a limitation that it requires authentification even for public packages like ours. 
You will need a registered GitHub account, generate a [personal access token (PAT)](https://github.com/settings/tokens/new) 
with at least a *read:packages* permission and use your e-mail and the generated 
token as a password to pull the packages and build the project.

[完整的 GitHub NuGet 包文档。](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry)

## Building
此存储库中的所有源都可以使用 .NET 8.0 SDK 进行编译。 建议使用免费的 Visual Studio Community 进行开发。安装 Visual Studio 时建议的最小工作负载为： .NET 桌面开发、ASP.NET 和 Web 开发、Node.js开发。

由于主机 SLS4All Compact 软件旨在在嵌入式计算机上运行，例如 Raspberry Pi 5， 以下代码将克隆存储库并为平台构建软件（您可以在任何支持 .NET SDK 的操作系统上构建它，包括 Windows 和非 ARM Linux）。 强烈建议使用至少 4GB RAM 的 64 位操作系统来运行编译软件。这意味着您应该使用 Raspberry Pi OS（以前称为 Raspbian）的 64 位变体 如果您将在 Raspberry Pi 上运行它。linux-arm64

您还需要最新的 NPM，这是构建软件的 Web 部件在内部所必需的

```
#更新软件包索引
sudo apt update && sudo apt upgrade  
#安装Node.js和NPM：
sudo apt install nodejs npm

#安装net8.0 安装脚本
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
#赋予可执行权限
chmod +x ./dotnet-install.sh
#运行安装工具
./dotnet-install.sh
#安装环境变量
export DOTNET_ROOT=$HOME/.dotnet
export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools
#拉取库文件
git clone https://github.com/13145210220/SLSA.git
#跳转到目标文件夹
cd SLSA/SLS4All.Compact.PrinterApp
#执行编译程序
dotnet build -c Release
dotnet publish -c Release -r linux-arm64 --self-contained
#进入目标文件夹
cd  /SLSA/SLS4All.Compact.PrinterApp/bin/Release/net8.0/linux-arm64/publish/
#启动软件
./SLS4All.Compact.PrinterApp --environment Development

# 当前目录的内容应该被复制 
# 正确地配置并复制到嵌入式（或开发用）计算机上
# 使用辅助脚本启动，但至少要通过例如以下方式：
# ./SLS4All.Compact.PrinterApp --environment Development
#
# 然后你应该在那台计算机上打开浏览器（最好是Chromium）。
# 软件运行的那台计算机上。典型的地址是
# http://localhost:5000 或者 http://localhost
# 根据配置，请将 localhost 替换为
# 软件所在计算机的任何其他地址。
```

## PrinterApp system dependencies

在嵌入式 PC 上运行的编译软件和捆绑脚本的全部功能存在一些依赖性。

如果嵌入式 PC 是带有 Raspberry PI OS 的 Raspberry PI 5，则可以使用以下方法进行安装：

```
sudo apt-get update
sudo apt-get install -y \
  xinput \
  stm32flash \
  avrdude \
  libffi-dev \
  libusb-dev \
  libusb-1.0 \
  pqiv \
  wmctrl \
  xdotool
```

# Klipper firmware
为了在开发过程中运行软件，不需要其他硬件组件。虚假（测试）实现可用于大多数接口。但是，对于实际 打印时，预计将 SLS4All Compact 软件与其他软件和硬件组件连接起来 运行 Klipper MCU 固件。

典型的设置是 SLS4All Compact 软件在 Raspberry Pi 嵌入式计算机上运行， 使用它还可以运行Klipper MCU Linux主机进程（SLS4All Compact将启动它 如果已配置，则自身），并且还会有一个或两个额外的硬件板 （Bigtreetech SKR 和 Arduino 板）用于控制其他硬件部件。所有这些额外的硬件 软件组件预计将运行 Klipper MCU 固件并连接到嵌入式 计算机（最好通过 USB）。

我们对 Klipper 源进行了修改，这些修改是单独提供的 在我们的 GitHub 上。请注意，一些 我们的修改是特定于硬件的。我们目前支持Klipper固件运行 在上面提到的硬件上，即 Linux 主机、Bigtreetech SKR v1.4 TURBO 和 Arduino Nano。

另请注意，SLS4All Compact 不使用 Klipper Python 实现， 仅 Klipper MCU 固件。在 Klipper 源中，对应于 src 子目录（即我们不使用 klippy 目录的内容）。

我们要感谢 Kevin O'Connor 和所有其他 Klipper 作者 和维护者。
