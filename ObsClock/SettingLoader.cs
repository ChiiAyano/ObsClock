using ObsClock.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace ObsClock
{
    /// <summary>
    /// 設定の読み書きを提供します。
    /// </summary>
    public class SettingLoader
    {
        private static string StartupPath { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        private static string SettingPath => Path.Combine(StartupPath, "settings.json");

        /// <summary>
        /// 設定をロードします。ファイルがない場合は既定値で新しく生成します。
        /// </summary>
        /// <returns></returns>
        public static SettingDataModel Load()
        {
            var json = string.Empty;

            if (!File.Exists(SettingPath))
            {
                var def = new SettingDataModel();
                Save(def);
                return def;
            }

            using (var sr = new StreamReader(SettingPath))
            {
                json = sr.ReadToEnd();
            }

            var data = JsonConvert.DeserializeObject<SettingDataModel>(json);
            return data;
        }

        /// <summary>
        /// 設定を保存します。
        /// </summary>
        /// <param name="data"></param>
        public static void Save(SettingDataModel data)
        {
            var json = JsonConvert.SerializeObject(data);

            using var wr = new StreamWriter(SettingPath, false);

            wr.WriteLine(json);
        }
    }
}
