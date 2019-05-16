using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;

class File {
    private byte[] log;
    private byte[] log_temp;

    static void Main(string[] args) {
        File f = new File();

        // string LO3path = "/Users/bobby/Downloads/Work/Log解析/LOG_FILE/LO3/034002LO300007.100.7A3";
        string YHDPpath = "/Users/bobby/Downloads/Work/Log解析/LOG_FILE/YHDP/TXN_4A_02191012_20181022175218_02.DAT";
        // f.LO3(LO3path);
        f.YHDP(YHDPpath);
    }

    private void LO3(string path) {
        FileStream reader = new FileStream(path, FileMode.Open);
        log = new byte[(int)reader.Length]; //1277
        reader.Read(log, 0, (int)reader.Length);
        reader.Close();

        while (true) {
            if (log[1] == 110 || log[1] == 111 || log[1] == 112 || log[1] == 113) {
                #region datas
                string[] datas = new string[56];
                datas[0] = log[0].ToString();
                datas[1] = log[1].ToString();
                datas[2] = log[2].ToString();
                datas[3] = byte_convert_unix_date_time(3, 4, true);
                datas[4] = byte_to_hex_string_to_hex(7, 7, true).ToString();
                datas[5] = log[14].ToString(); 
                datas[6] = log[15].ToString();
                datas[7] = byte_to_hex_string_to_hex(16, 3, true).ToString();
                datas[8] = byte_to_hex_string_to_hex(19, 3, true).ToString();
                datas[9] = byte_to_hex_string_to_hex(22, 2, true).ToString();
                datas[10] = log[24].ToString();
                datas[11] = "0x" + byte_to_hex_string_to_hex(25, 1, true).ToString();
                datas[12] = "0x" + byte_to_hex_string_to_hex(26, 2, true).ToString();
                datas[13] = log[28].ToString();
                datas[14] = log[29].ToString();
                datas[15] = log[30].ToString();
                datas[16] = byte_to_hex_string_to_hex(31, 3, true).ToString();
                datas[17] = byte_to_hex_string_to_hex(34, 3, true).ToString();
                datas[18] = byte_to_hex_string_to_hex(37, 2, true).ToString();
                datas[19] = log[39].ToString();
                datas[20] = byte_to_hex_string_to_hex(40, 3, true).ToString();
                datas[21] = byte_to_hex_string_to_hex(43, 3, true).ToString();
                datas[22] = log[46].ToString();
                datas[23] = byte_to_hex_string_to_hex(47, 3, true).ToString();
                datas[24] = byte_convert_unix_date_time(50, 4, true).ToString();
                datas[25] = "0x" + byte_to_hex_string_to_hex(54, 6, true).ToString();
                datas[26] = byte_to_hex_string_to_hex(60, 3, true).ToString();
                datas[27] = byte_to_hex_string_to_hex(63, 2, true).ToString();
                datas[28] = log[65].ToString();
                datas[29] = log[66].ToString();
                datas[30] = byte_to_hex_string_to_hex(67, 4, true).ToString();
                datas[31] = byte_to_hex_string_to_hex(71, 4, true).ToString();
                datas[32] = byte_to_hex_string_to_hex(75, 2, true).ToString();
                datas[33] = byte_convert_unix_date_time(77, 4, true).ToString();
                datas[34] = byte_to_hex_string_to_hex(81, 2, true).ToString();
                datas[35] = log[83].ToString();
                datas[36] = byte_to_hex_string_to_hex(84, 3, true).ToString();
                datas[37] = log[87].ToString();
                datas[38] = byte_to_hex_string_to_hex(88, 3, true).ToString();
                datas[39] = byte_to_hex_string_to_hex(91, 3, true).ToString();
                datas[40] = byte_to_hex_string_to_hex(94, 3, true).ToString();
                datas[41] = byte_to_hex_string_to_hex(97, 2, true).ToString();
                datas[42] = byte_to_hex_string_to_hex(99, 2, true).ToString();
                datas[43] = byte_to_hex_string_to_hex(101, 3, true).ToString();
                datas[44] = rfu_format(104, 1, false);
                datas[45] = rfu_format(105, 12).ToString() ;
                datas[46] = log[117].ToString();
                datas[47] = log[118].ToString();
                datas[48] = byte_to_hex_string_to_hex(119, 2).ToString();
                datas[49] = byte_to_hex_string_to_hex(121, 2, true).ToString();
                datas[50] = byte_to_hex_string_to_hex(123, 2, false).ToString();
                datas[51] = byte_to_hex_string_to_hex(125, 2, false).ToString();
                datas[52] = log[127].ToString();
                datas[53] = byte_to_hex_string_to_hex(128, 1, true).ToString();
                datas[54] = rfu_format(129, 5).ToString();
                datas[55] = log[134].ToString();
                #endregion
                foreach (string data in datas) {
                    Console.WriteLine(data);
                }
            }

            int sourceIndex = log[0] + 1;
            if (log.Length - sourceIndex == 0) break;
            log_temp = new byte[log.Length - sourceIndex];
            Array.Copy(log, sourceIndex, log_temp, 0, log.Length - sourceIndex);
            log = log_temp;
        }
    }

    private void YHDP(string path) {
        FileStream reader = new FileStream(path, FileMode.Open);
        log = new byte[(int)reader.Length]; //14076
        reader.Read(log, 0, (int)reader.Length);
        reader.Close();

        #region data
        string[] datas = new string[] {
            Byte_To_Char_To_String(66, 2),
            Byte_To_Hex(68, 4),
            Byte_To_Hex(72, 48),
            Byte_To_Hex(120, 48),
            Byte_To_Hex(168, 48),
            Hex_To_Int_Reverse(217, 2),

            Byte_To_Hex(218, 4), //?? time
            
            "0x" + Byte_To_Hex(222, 1),
            Hex_To_Int_Reverse(224, 2),
            Hex_To_Int_Reverse(226, 2),
            Hex_To_Int_Reverse(228, 2),
            "0x" + Byte_To_Hex(229, 1),
            "0x" + Byte_To_Hex(230, 1),
            Hex_Reverse(234, 4),
            Byte_To_Hex(235, 8),
            Byte_To_Char_To_String(243, 8),
            Byte_To_Hex(251, 8),
            Byte_To_Hex(259, 8),
            Byte_To_Hex(267, 8),
            "0x" + Byte_To_Hex(275, 8),

            Byte_To_Hex(283, 6), //??????

            Byte_To_Hex(289, 8),
            Hex_To_Int(297, 6),

            Byte_To_Hex(303, 14), //???

            Byte_To_Hex(317, 4),
            Byte_To_Char_To_String(321, 15),
            Hex_To_Int_Reverse(338, 2),

            Byte_To_Hex(340, 4), //time
            Byte_To_Hex(344, 48), //?????
            
            "0x" + Byte_To_Hex(392, 1),
            Byte_To_Hex(393, 4),
            
        };
        #endregion
        foreach (string data in datas) {
            Console.WriteLine(data);
            Console.WriteLine();
        }

    }

    private string Byte_To_Char_To_String(int index, int length) {
        StringBuilder sb = new StringBuilder();
        for (int i = index ; i < index + length ; i++) {
            sb.Append((char)log[i]);
        }
        return sb.ToString();
    }

    private string Byte_To_Hex(int index, int length) {
        StringBuilder sb = new StringBuilder();
        for (int i = index ; i < index + length ; i++) {
            sb.Append(Convert.ToString(log[i], 16).PadLeft(2, '0').ToUpper());
        }
        return sb.ToString();
    }

    private string Hex_To_Int_Reverse(int index, int length) {
        StringBuilder sb = new StringBuilder();
        for (int i = index ; i > index - length ; i--) {
            sb.Append(Byte_To_Hex(i, 1));
        }
        return Convert.ToInt32(sb.ToString(), 16).ToString();
    }

    private string Hex_To_Int(int index, int length) {
        return Convert.ToInt32(Byte_To_Hex(index, length), 16).ToString();
    }

    private string Hex_Reverse(int index, int length) {
        StringBuilder sb = new StringBuilder();
        for  (int i = index ; i > index - length ; i--) {
            sb.Append(Byte_To_Hex(i, 1));
        }
        return sb.ToString();
    }

    // private void Byte_To_Time(int index, int length) {
    //     Console.WriteLine(Byte_To_Hex(index, length));
    // }


    #region utility


    private String byte_convert_unix_date_time(int index, int length, bool LSB = false)
    {

        log_temp = new byte[length];
        Array.Copy(log, index, log_temp, 0, length);

        if (LSB) { log_temp = change_hlbyte(log_temp); }
        String rltStr = "";
        for (int i = 0; i < log_temp.Length; i++)
        {
            rltStr += Convert.ToString(log_temp[i], 16).PadLeft(2, '0');
        }
        long unixTime = Convert.ToInt64(rltStr, 16);

        DateTime origin1 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        origin1 = origin1.AddSeconds(unixTime);

        return origin1.ToString("yyyy/MM/dd HH:mm:ss");
    }

    private byte[] change_hlbyte(byte[] byte_temp)
    {
        byte[] byte_convert = new byte[byte_temp.Length];

        int j = 0;
        for (int i = byte_temp.Length - 1; i >= 0; i--)
        {
            byte_convert[j] = byte_temp[i];
            j++;
        }

        return byte_convert;
    }

    private String byte_to_hex_string(int index, int length, bool LSB = false)
    {
        log_temp = new byte[length];
        Array.Copy(log, index, log_temp, 0, length);

        if (LSB) { log_temp = change_hlbyte(log_temp); }

        String hex_string = string.Empty;
        if (log_temp != null)
        {
            StringBuilder strB = new StringBuilder();

            for (int i = 0; i < log_temp.Length; i++)
            {
                strB.Append(log_temp[i].ToString("X2"));
            }
            hex_string = strB.ToString();
        }
        return hex_string;
    }

    private uint byte_to_hex_string_to_hex(int index, int length, bool LSB = false) //e.g. AAAA to 0xAAAA
    {
        log_temp = new byte[length];
        Array.Copy(log, index, log_temp, 0, length);

        if (LSB) { log_temp = change_hlbyte(log_temp); }

        String hex_string = string.Empty;
        if (log_temp != null)
        {
            StringBuilder strB = new StringBuilder();

            for (int i = 0; i < log_temp.Length; i++)
            {
                strB.Append(log_temp[i].ToString("X2"));
            }
            hex_string = strB.ToString();
        }

        return Convert.ToUInt32(hex_string, 16);
    }

    private String rfu_format(int index, int length, bool LSB = false) //e.g. 0 0 0 0 31 35
    {
        log_temp = new byte[length];
        Array.Copy(log, index, log_temp, 0, length);

        if (LSB) { log_temp = change_hlbyte(log_temp); }

        String string_format = "";
        if (log_temp != null)
        {
            for (int i = 0; i < log_temp.Length; i++)
            {
                string_format += log_temp[i] + " ";
            }
        }

        return string_format;
    }
    #endregion

}