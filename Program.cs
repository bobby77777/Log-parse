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
        string YHDPpath = "/Users/bobby/Downloads/Work/Log解析/LOG_FILE/YHDP/TXN_93_02071001_20181102155600_06.DAT";
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
                #region data
                string[] data = new string[56];
                data[0] = log[0].ToString();
                data[1] = log[1].ToString();
                data[2] = log[2].ToString();
                data[3] = byte_convert_unix_date_time(3, 4, true);
                data[4] = byte_to_hex_string_to_hex(7, 7, true).ToString();
                data[5] = log[14].ToString(); 
                data[6] = log[15].ToString();
                data[7] = byte_to_hex_string_to_hex(16, 3, true).ToString();
                data[8] = byte_to_hex_string_to_hex(19, 3, true).ToString();
                data[9] = byte_to_hex_string_to_hex(22, 2, true).ToString();
                data[10] = log[24].ToString();
                data[11] = "0x" + byte_to_hex_string_to_hex(25, 1, true).ToString();
                data[12] = "0x" + byte_to_hex_string_to_hex(26, 2, true).ToString();
                data[13] = log[28].ToString();
                data[14] = log[29].ToString();
                data[15] = log[30].ToString();
                data[16] = byte_to_hex_string_to_hex(31, 3, true).ToString();
                data[17] = byte_to_hex_string_to_hex(34, 3, true).ToString();
                data[18] = byte_to_hex_string_to_hex(37, 2, true).ToString();
                data[19] = log[39].ToString();
                data[20] = byte_to_hex_string_to_hex(40, 3, true).ToString();
                data[21] = byte_to_hex_string_to_hex(43, 3, true).ToString();
                data[22] = log[46].ToString();
                data[23] = byte_to_hex_string_to_hex(47, 3, true).ToString();
                data[24] = byte_convert_unix_date_time(50, 4, true).ToString();
                data[25] = "0x" + byte_to_hex_string_to_hex(54, 6, true).ToString();
                data[26] = byte_to_hex_string_to_hex(60, 3, true).ToString();
                data[27] = byte_to_hex_string_to_hex(63, 2, true).ToString();
                data[28] = log[65].ToString();
                data[29] = log[66].ToString();
                data[30] = byte_to_hex_string_to_hex(67, 4, true).ToString();
                data[31] = byte_to_hex_string_to_hex(71, 4, true).ToString();
                data[32] = byte_to_hex_string_to_hex(75, 2, true).ToString();
                data[33] = byte_convert_unix_date_time(77, 4, true).ToString();
                data[34] = byte_to_hex_string_to_hex(81, 2, true).ToString();
                data[35] = log[83].ToString();
                data[36] = byte_to_hex_string_to_hex(84, 3, true).ToString();
                data[37] = log[87].ToString();
                data[38] = byte_to_hex_string_to_hex(88, 3, true).ToString();
                data[39] = byte_to_hex_string_to_hex(91, 3, true).ToString();
                data[40] = byte_to_hex_string_to_hex(94, 3, true).ToString();
                data[41] = byte_to_hex_string_to_hex(97, 2, true).ToString();
                data[42] = byte_to_hex_string_to_hex(99, 2, true).ToString();
                data[43] = byte_to_hex_string_to_hex(101, 3, true).ToString();
                data[44] = rfu_format(104, 1, false);
                data[45] = rfu_format(105, 12).ToString() ;
                data[46] = log[117].ToString();
                data[47] = log[118].ToString();
                data[48] = byte_to_hex_string_to_hex(119, 2).ToString();
                data[49] = byte_to_hex_string_to_hex(121, 2, true).ToString();
                data[50] = byte_to_hex_string_to_hex(123, 2, false).ToString();
                data[51] = byte_to_hex_string_to_hex(125, 2, false).ToString();
                data[52] = log[127].ToString();
                data[53] = byte_to_hex_string_to_hex(128, 1, true).ToString();
                data[54] = rfu_format(129, 5).ToString();
                data[55] = log[134].ToString();
                #endregion
                foreach (string da in data) {
                    Console.WriteLine(da);
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

        
    }

    #region utility
    private String byte_convert_unix_date_time(int index, int num, bool LSB = false)
    {

        log_temp = new byte[num];
        Array.Copy(log, index, log_temp, 0, num);

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

    private String byte_to_hex_string(int index, int num, bool LSB = false)
    {
        log_temp = new byte[num];
        Array.Copy(log, index, log_temp, 0, num);

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

    private uint byte_to_hex_string_to_hex(int index, int num, bool LSB = false) //e.g. AAAA to 0xAAAA
    {
        log_temp = new byte[num];
        Array.Copy(log, index, log_temp, 0, num);

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

    private String rfu_format(int index, int num, bool LSB = false) //e.g. 0 0 0 0 31 35
    {
        log_temp = new byte[num];
        Array.Copy(log, index, log_temp, 0, num);

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