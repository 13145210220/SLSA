// 版权所有 (C) 2024 anyteq development s.r.o.
// 
// 此文件是SLS4All项目（sls4all.com）的一部分，并根据位于仓库根目录的LICENSE.txt文件中描述的许可协议提供。

namespace SLS4All.Compact.Configuration
{
    public interface IAppDataWriter
    {
        // 私有配置文件夹名称
        public const string PrivateOptionsDirectory = ".PrivateConfiguration";
        // 私有数据文件夹名称
        public const string PrivateDataDirectory = ".PrivateData";
        // 非持久性临时文件夹名称
        public const string NonMemoryTempDirectory = ".Temp";
        // 持久性临时文件夹名称
        public const string PersistentTempDirectory = ".TempPersistent";
        // 公共配置类型文件夹名称
        public const string PublicOptionsTypeDirectory = "Configuration";
        // 打印会话文件夹名称
        public const string PrintSessionsDirectory = "PrintSessions";
        // 打印配置文件文件夹名称
        public const string PrintProfilesDirectory = "PrintProfiles";
        // 作业文件夹名称
        public const string JobsDirectory = "Jobs";
        // 备份文件夹名称
        public const string BackupsDirectory = "Backups";
        // 对象文件夹名称
        public const string ObjectsDirectory = "Objects";
        // 归档文件夹名称
        public const string ArchiveDirectory = "Archive";
        // 上一个版本文件夹名称
        public const string PreviousDirectory = "Previous";
        // 当前版本文件夹名称
        public const string CurrentDirectory = "Current";
        // 暂存文件夹名称
        public const string StagingDirectory = "Staging";
        // 准备文件夹名称
        public const string PrepareDirectory = "Prepare";
        // 表面文件夹名称
        public const string SurfaceDirectory = "Surface";

        // 获取基本目录路径
        string GetBaseDirectory();
        // 获取备份目录路径
        string GetBackupsDirectory();
        // 获取表面目录路径
        string GetSurfaceDirectory();
        // 获取非持久性临时目录路径
        string GetNonMemoryTempDirectory();
        // 获取持久性临时目录路径
        string GetPersistentTempDirectory();
        // 获取私有数据目录路径
        string GetPrivateDataDirectory();
        // 获取打印会话目录路径
        string GetPrintSessionsDirectory();
        // 获取打印配置文件目录路径
        string GetPrintProfilesDirectory();
        // 获取作业目录路径
        string GetJobsDirectory();
        // 获取对象目录路径
        string GetObjectsDirectory();
        // 获取公共配置目录路径
        string GetPublicOptionsDirectory();
        // 根据选项类型获取私有配置文件名
        string GetPrivateOptionsFilename(Type optionsType);
    }
}
