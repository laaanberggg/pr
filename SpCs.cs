using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace murzaev
{
    public partial class Ведущие
    {
        public string Speaker
        {
            get
            {
                switch (IDSpeak)
                {
                    case 1:
                        return "Ведущий Мухина Л.В.";
                    case 2:
                        return "Ведущий Мухин Н.А.";
                    case 3:
                        return "Ведущий Дергачев Д.А.";
                    case 4:
                        return "Ведущий Тараканова Н.А.";
                    default:
                        return "---";
                }
            }
        }
    }
}
