using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Languages
    {
        public static IEnumerable<Language> GetAll(){
            return Language.FindAll();
        }
    }
}
