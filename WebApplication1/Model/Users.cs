using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Model {
    public class users {
        public int ID { get; set; }       //主键
        public string Name { get; set; }  //用户名称
        public int Age { get; set; }    //用户年龄
        public int Number { get; set; } //用户手机号码
    }
}