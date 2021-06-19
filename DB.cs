using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SmartDeviceProject1
{
    class DB
    {
        public DB()
        {
            barcodes = new Dictionary<string, string>();
        }

        Dictionary<string, string> barcodes;
        const string FILENAME = "db";

        public bool Contains(string barcode)
        {
            return barcodes.ContainsKey(barcode);
        }

        public int Count
        {
            get { return barcodes.Count; }
        }

        public void AddBarcode(string barcode)
        {
            barcodes[barcode] = "";
        }

        public void Load()
        {
            barcodes.Clear();
            if (!File.Exists(FILENAME))
                return;
            FileStream fs = File.OpenRead(FILENAME);
            BinaryReader br = new BinaryReader(fs);
            int count = br.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                barcodes.Add(br.ReadString(),"");
            }
            br.Close();
        }

        public void Save()
        {
            FileStream fs = File.OpenWrite(FILENAME);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(barcodes.Count);
            //line-separated text?
            foreach (var kv in barcodes)
            {
                 bw.Write(kv.Key);
            }
            bw.Close();
        }
    }
}
