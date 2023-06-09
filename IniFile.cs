using IniParser;
using IniParser.Model;
using System;

namespace r6sSettingsManager
{
    public class IniFile
    {
        // フィールド
        //ファイル名,path
        private string filename;
        private string filePath;

        // 垂直水平のMultiUnit,垂直,水平
        private float multiplierUnit;
        private int sensYaw;
        private int sensPitch;

        //ads感度
        private int ads1x;
        private int ads1xHalf;
        private int ads2x;
        private int ads2xHalf;
        private int ads3x;
        private int ads4x;
        private int ads5x;
        private int ads12x;


        //プロパティ
        public IniFile(string filePath)
        {
            this.filePath = filePath;
        }

        // 垂直水平のMultiUnit,垂直,水平
        public float MultiplierUnit { get { return multiplierUnit; } set { multiplierUnit = value; } }
        public int SensYaw { get { return sensYaw; } set { sensYaw = value; } }
        public int SensPitch { get { return sensPitch; } set { sensPitch = value; } }

        // Ads感度
        public int Ads1x { get { return ads1x; } set { ads1x = value; } }
        public int Ads1xHalf { get { return ads1xHalf; } set { ads1xHalf = value; } }
        public int Ads2x { get { return ads2x; } set { ads2x = value; } }
        public int Ads2xHalf { get { return ads2xHalf; } set { ads2xHalf = value; } }
        public int Ads3x { get { return ads3x; } set { ads3x = value; } }
        public int Ads4x { get { return ads4x; } set { ads4x = value; } }
        public int Ads5x { get { return ads5x; } set { ads5x = value; } }
        public int Ads12x { get { return ads12x; } set { ads12x = value; } }


        // 読み込んでフィールドに代入
        public void LoadSensValue()
        {
            // Ini読み込み
            var parser = new FileIniDataParser();
            IniData iniData = parser.ReadFile(filePath);

            // 垂直、水平、垂直水平のMultiUnit
            MultiplierUnit = float.Parse(iniData["INPUT"]["MouseSensitivityMultiplierUnit"]);
            SensYaw = int.Parse(iniData["INPUT"]["MouseYawSensitivity"]);
            SensPitch = int.Parse(iniData["INPUT"]["MousePitchSensitivity"]);

            Ads1x = int.Parse(iniData["INPUT"]["ADSMouseSensitivity1x"]);
            Ads1xHalf = int.Parse(iniData["INPUT"]["ADSMouseSensitivity1xHalf"]);
            Ads2x = int.Parse(iniData["INPUT"]["ADSMouseSensitivity2x"]);
            Ads2xHalf = int.Parse(iniData["INPUT"]["ADSMouseSensitivity2xHalf"]);
            Ads3x = int.Parse(iniData["INPUT"]["ADSMouseSensitivity3x"]);
            Ads4x = int.Parse(iniData["INPUT"]["ADSMouseSensitivity4x"]);
            Ads5x = int.Parse(iniData["INPUT"]["ADSMouseSensitivity5x"]);
            Ads12x = int.Parse(iniData["INPUT"]["ADSMouseSensitivity12x"]);
        }

    }
}