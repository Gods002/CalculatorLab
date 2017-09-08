using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    //เอาความสามารถของclass calculator
    //  RPNcalculatorengine is subclass,CalculatorEngine is superclass
    class RPNcalculatorengine : CalculatorEngine
    {
        public string Process(string str)
        {
            Stack cur = new Stack();
            string[] parts = str.Split(' ');
            string first, second,result;
            for(int i =0; i < parts.Length ;i++)
            { 
                if (isNumber(parts[i]))
                {
                    cur.Push(parts[i]);
                }
                if(parts[i]== " ")
                {
                    break;
                }
                if (isOperator(parts[i]))
                {
                    second = cur.Pop().ToString();
                    first = cur.Pop().ToString();
                    result = calculate(parts[i], first, second);
                    cur.Push(result);
                }         
            }
            result= cur.Pop().ToString();

            return result;
            //split str
            //loop ไปเรื่อยยๆๆ
            //  ถ้าเป็นเลขให้
            //   ใส่ลงไปใน stack
            //  ถ้าเป็น เคื่องหมาย ให้ popมาสองตัว
        }

    }
}
