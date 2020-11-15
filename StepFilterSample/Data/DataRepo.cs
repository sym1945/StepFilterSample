using System.Collections.Generic;

namespace StepFilterSample
{
    public class DataRepo
    {
        public List<DataModel> Datas { get; set; }

        public DataRepo()
        {
            Datas = new List<DataModel>
            {
                new DataModel { FirstValue = "F1", SecondValue = "S1", ThirdValue = "T1", FourthValue = "F1" },
                new DataModel { FirstValue = "F1", SecondValue = "S1", ThirdValue = "T1", FourthValue = "F1-1" },
                new DataModel { FirstValue = "F1", SecondValue = "S1-1", ThirdValue = "T1", FourthValue = "F1" },
                new DataModel { FirstValue = "F1", SecondValue = "S1-1", ThirdValue = "T1-1", FourthValue = "F1" },
                new DataModel { FirstValue = "F1", SecondValue = "S1-1", ThirdValue = "T1-1", FourthValue = "F1-1" },

                new DataModel { FirstValue = "F2", SecondValue = "S2", ThirdValue = "T2", FourthValue = "F2" },
                new DataModel { FirstValue = "F2", SecondValue = "S2", ThirdValue = "T2", FourthValue = "F2-1" },
                new DataModel { FirstValue = "F2", SecondValue = "S2-1", ThirdValue = "T2", FourthValue = "F2" },
                new DataModel { FirstValue = "F2", SecondValue = "S2-1", ThirdValue = "T2-1", FourthValue = "F2" },
                new DataModel { FirstValue = "F2", SecondValue = "S2-1", ThirdValue = "T2-1", FourthValue = "F2-1" },

                new DataModel { FirstValue = "F3", SecondValue = "S3", ThirdValue = "T3", FourthValue = "F3" },
                new DataModel { FirstValue = "F3", SecondValue = "S3", ThirdValue = "T3", FourthValue = "F3-1" },
                new DataModel { FirstValue = "F3", SecondValue = "S3-1", ThirdValue = "T3", FourthValue = "F3" },
                new DataModel { FirstValue = "F3", SecondValue = "S3-1", ThirdValue = "T3-1", FourthValue = "F3" },
                new DataModel { FirstValue = "F3", SecondValue = "S3-1", ThirdValue = "T3-1", FourthValue = "F3-1" },
            };

        }

    }
}