using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace stockdata.utils
{
    class SamFileData
    {
        private string _fileName = null;
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
                parseFile();
            }
        }
        public bool IsSuccess { get; private set; } = false;

        public string[] HeaderNames { get; private set; }
        public List<List<SamFileDataStruct>> DataItems { get; private set; }

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public SamFileData() { }

        /// <summary>
        /// 파일명을 입력으로 받는 생성자
        /// </summary>
        /// <param name="fileName"></param>
        public SamFileData(string fileName)
        {
            this.FileName = fileName;
        }

        /// <summary>
        /// 파일 분석기
        /// </summary>
        public void parseFile()
        {
            if (!File.Exists(FileName))
            {
                Console.WriteLine("Warning: file not found. " + FileName);
                return;
            }

            string[] fileData = File.ReadAllLines(FileName, Encoding.Default);
            // 최소 2줄이 안 되면 분석하지 않는다. (첫줄: 헤더, 2번줄부터: 데이터 - 2줄이 안 된다는 것은 데이터가 없다는 의미)
            if (fileData.Length < 2)
            {
                Console.WriteLine("Warning: file empty. " + FileName);
                return;
            }

            HeaderNames = fileData[0].Split(new char[] { '\t' });
            DataItems = new List<List<SamFileDataStruct>>();
            for (int i = 1; i < fileData.Length; i++)
            {
                string[] items = fileData[i].Split(new char[] { '\t' });

                List<SamFileDataStruct> itemList = new List<SamFileDataStruct>();
                for (int j = 0; j < items.Length || j < HeaderNames.Length; j++)
                {
                    SamFileDataStruct samItem = new SamFileDataStruct();
                    samItem.FieldName = HeaderNames[j];
                    samItem.FieldValue = items[j];
                    itemList.Add(samItem);
                }
                DataItems.Add(itemList);
            }

            IsSuccess = true;
            Console.WriteLine("Sam file 분석 완료.");
            //string json = JsonConvert.SerializeObject(DataItems, Formatting.Indented);
            //Console.WriteLine(json);
        }

    }


    class SamFileDataStruct
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }

}
