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
SLS4All NuGet packages for parts that have not yet been open-sourced are published on GitHub package source.
These NuGet packages are referenced from the projects present in this repository.
Path to NuGet package source is https://nuget.pkg.github.com/sls4all/index.json.
This source should already be configured in nuget.config in the root of this repository. 
Please note that GitHub [currently requires](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#authenticating-with-a-personal-access-token) a registered GitHub account and associated token to download NuGet packages, even if the packages are marked public. 

GitHub package source has a limitation that it requires authentification even for public packages like ours. 
You will need a registered GitHub account, generate a [personal access token (PAT)](https://github.com/settings/tokens/new) 
with at least a *read:packages* permission and use your e-mail and the generated 
token as a password to pull the packages and build the project.

[Full GitHub NuGet packages documentation.](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry)

## Building
All sources in this repository are compilable using [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0). 
We recommend free [Visual Studio Community](https://visualstudio.microsoft.com/cs/vs/community/) for development. Suggested minumum workloads when installing Visual Studio are: 
.NET desktop development, ASP.NET and web development, Node.js development.

Since the host *SLS4All Compact* software is intended to be run on embedded computer, like Raspberry Pi 5,
the following code will clone the repository and build the software for `linux-arm64` platform (you can build it on any OS supporting .NET SDK, including Windows and non ARM Linux). 
64-bit OS with at least 4GB RAM for running the compiled software is very strongly recommended. That means you should use 64-bit variant of Raspberry Pi OS (formerly Raspbian) 
if you will be running it on Raspberry Pi.

You will also need latest [NPM](https://www.npmjs.com/) that is internally required to build the web parts of the software.

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

There are some dependencies for full functionality of the compiled software and bundled scripts running on the embedded PC.

If the embedded PC is Raspberry PI 5 with Raspberry PI OS, these can be installed using:

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
For running the software during development no other hardware components are neccessary.
*Fake* (testing) implementations are available for most of the interfaces. However for actual 
printing it is expected to connect the *SLS4All Compact* software with other SW and HW components 
running Klipper MCU Firmware.

Typical setup is that *SLS4All Compact* software runs on Raspberry Pi embedded computer, 
with it there also runs a Klipper MCU Linux host process (*SLS4All Compact* will start it 
itself if configured) and also there would be one or two additional HW boards 
(Bigtreetech SKR and Arduino board) for controlling the other HW parts. All these additional HW 
and SW components are expected to run Klipper MCU Firmware and be connected to the embedded 
computer (preferably via USB).

We have made modifications to *Klipper* sources and these are made available separately
on our [GitHub](https://github.com/sls4all/SLS4All.Compact.Klipper). Please note that some 
of our modifications are HW specific. We currently support *Klipper* firmware running
on HW metioned above, i.e. Linux Host, Bigtreetech SKR v1.4 TURBO, and Arduino Nano.

Please also note that *SLS4All Compact* does not utilize Klipper Python implementation, 
only the Klipper MCU Firmware. In *Klipper* sources that corresponds to 
[src](https://github.com/sls4all/SLS4All.Compact.Klipper/tree/master/src) 
subdirectory (i.e. we do not utilize contents of 
[klippy](https://github.com/sls4all/SLS4All.Compact.Klipper/tree/master/klippy) directory).

We would like to thank Kevin O'Connor and all other [Klipper](https://www.klipper3d.org/) authors 
and maintainers.
