

    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bus_Station
{
    class Vaild
    {

        public bool chechMails(string mail)
        {
            // number of @ 
            if (mail.Length < 6)
                return false;

            int posOfAt = -1;
            //To determine The position of ' @ '
            for (int i = 0; i < mail.Length; i++)
            {
               
                    posOfAt = i + 1;
                    break;
                
            }
            // to determine of Length
            int size = mail.Length;

            if (mail[size - 1] == 'm' && mail[size - 2] == 'o' && mail[size - 3] == 'c' && mail[size - 4] == '.' && size - 5 > posOfAt && posOfAt != -1 && posOfAt > 0)
                return true;

            return false;

        }


        public bool checkPhoneNum(string phoneNum)
        {
            // to determine the number is 0 - 1
            if (phoneNum.Length != 11 || phoneNum[0] != '0' || phoneNum[1] != '1' || !(phoneNum[2] == '0' || phoneNum[2] == '1' || phoneNum[2] == '2' || phoneNum[2] == '5'))
                return false;
            // to Know that Phone_Number is Numbers and not Charcter and not -1 
            for (int i = 0; i < phoneNum.Length; i++)
            {
                if (!(phoneNum[i] >= '0' && phoneNum[i] <= '9'))
                    return false;

            }

            return true;
        }

    }

}


