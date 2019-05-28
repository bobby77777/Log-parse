using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;

class File {
    private byte[] log;
    private byte[] log_temp;

    static void Main(string[] args) {
        File parse = new File();
        Console.Write("Choose method(1.LO3, 2.YHDP, 3.ICASH, 4.IPASS, 5.S1S2): ");
        string choosestring;
        while ((choosestring = Console.ReadLine()) != "1" && choosestring != "2" && choosestring != "3" && choosestring != "4" && choosestring != "5") {
            Console.Write("input again: ");
        }
        int choose = Convert.ToInt16(choosestring);
        Console.WriteLine();
        try {
            switch (choose) {
                case 1:
                    string LO3path = "/Users/bobby/Downloads/Work/Log解析/LOG_FILE/LO3/034002LO300007.100.7A3";
                    parse.LO3(LO3path);
                    break;
                case 2:
                    string YHDPpath = "/Users/bobby/Downloads/Work/Log解析/LOG_FILE/YHDP/TXN_4A_02191012_20181022175218_02.DAT";
                    parse.YHDP(YHDPpath);
                    break;
                case 3:
                    string ICASHpath = "/Users/bobby/Downloads/Work/Log解析/LOG_FILE/ICASH/ICTX2LOG_BV-419467522_20190510092614.dat";
                    parse.ICASH(ICASHpath);
                    break;
                case 4:
                    string IPASSpath = "/Users/bobby/Downloads/Work/Log解析/LOG_FILE/IPASS/BVTI_07B61900910220190510105407.DAT";
                    parse.IPASS(IPASSpath);
                    break;
                case 5:
                    string S1S2path = "/Users/bobby/Downloads/Work/Log解析/LOG_FILE/S1S2/00220.034_00000034_00073_00005.20190510092614_001U.DAT";
                    parse.S1S2(S1S2path);
                    break;
                default:
                    break;
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    private void LO3(string path) {
        File_To_Log(path);

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
                Printdata(datas);
            }

            int sourceIndex = log[0] + 1;
            if (log.Length - sourceIndex == 0) break;
            LogChange(sourceIndex);
        }
    }

    private void YHDP(string path) {
        File_To_Log(path);
        LogChange(66);

        while (true) {
            string[] datas = new string[] {
                Byte_To_Char_To_String(0, 2),
                Byte_To_Hex(2, 4),
                Byte_To_Hex(6, 48),
                Byte_To_Hex(54, 48),
                Byte_To_Hex(102, 48),
                Byte_To_Hex_Reverse(150, 2, true),
                Byte_To_Time(152, 4, true),
                "0x" + Byte_To_Hex(156, 1),
                Byte_To_Hex_Reverse(157, 2, true),
                Byte_To_Hex_Reverse(159, 2, true),
                Byte_To_Hex_Reverse(161, 2, true),
                "0x" + Byte_To_Hex(163, 1),
                "0x" + Byte_To_Hex(164, 1),
                Byte_To_Hex_Reverse(165, 4, false),
                Byte_To_Hex(169, 8),
                Byte_To_Char_To_String(177, 8),
                Byte_To_Hex(185, 8),
                Byte_To_Hex(193, 8),
                Byte_To_Hex(201, 8),
                "0x" + Byte_To_Hex(209, 8),
                Byte_To_Char_To_String(217, 6),
                Byte_To_Hex(223, 8),
                Byte_To_Hex_To_Int(231, 6),
                Byte_To_Char_To_String(237, 14),
                Byte_To_Hex(251, 4),
                Byte_To_Char_To_String(254, 15),
                Byte_To_Hex_Reverse(269, 2, true),
                Byte_To_Time(271, 4, true),
                Byte_To_Hex(275, 48),
                "0x" + Byte_To_Hex(323, 1),
                Byte_To_Hex_To_Int(324, 4),
                Byte_To_Hex_To_Int(328, 4),
                Byte_To_Hex_To_Int(332, 2),
                Byte_To_Hex_To_Int(335, 1),
                Byte_To_Hex_To_Int(336, 2),
                Byte_To_Hex_To_Int(338, 2),
                Byte_To_Hex_To_Int(340, 1),
                Byte_To_Hex_To_Int(341, 2),
                Byte_To_Hex_To_Int(343, 2),
                "0x" + Byte_To_Hex(345, 1),
                Byte_To_Hex_To_Int(346, 2),
                Byte_To_Hex(348, 6),
                Byte_To_Char_To_String(354, 10),
                Byte_To_Char_To_String(364, 6),
                Byte_To_Time(370, 4, false),
                "0x" + Byte_To_Hex(374, 1),
                Byte_To_Hex_To_Int(375, 2),
                "0x" + Byte_To_Hex(377, 1),
                Byte_To_Hex_To_Int(378, 2),
                Byte_To_Hex_To_Int(380, 2),
                Byte_To_Hex_To_Int(382, 2),
                Byte_To_Hex(384, 8),
                "0x" + Byte_To_Hex(392, 1),
                "0x" + Byte_To_Hex(393, 1),
                Byte_To_Hex_To_Int(394, 4),
                Byte_To_Hex_To_Int(398, 4),
                Byte_To_Time(402, 4, false),
                Byte_To_Time(406, 4, false),
                Byte_To_Time(410, 4, false),
                Byte_To_Hex(414, 4),
                Byte_To_Hex(418, 4),
                Byte_To_Hex(422, 4),
                "0x" + Byte_To_Hex(426, 1),
                Byte_To_Time(427, 4, false),
                Byte_To_Hex_To_Int(431, 2),
                Byte_To_Hex_To_Int(433, 2),
                Byte_To_Hex(435, 2),
                "0x" + Byte_To_Hex(437, 1),
                Byte_To_Hex(438, 1),
                Byte_To_Hex(439, 1),
                "0x" + Byte_To_Hex(440, 1),
                "0x" + Byte_To_Hex(441, 4),
                "0x" + Byte_To_Hex(445, 1),
                Byte_To_Hex_To_Int(446, 1),
                Byte_To_Hex_To_Int(447, 1),
                Byte_To_Time(448, 2, false),
                Byte_To_Hex(450, 17),
            };
            Printdata(datas);
            LogChange(467);
            if (log.Length == 0) break;
        }
    }
    
    private void ICASH(string path) {
        File_To_Log(path);
        LogChange(36);

        while (true) {
            string[] datas = new string[] {
                Byte_To_Hex(0, 1),
                Byte_To_Time(1, 4, true),
                Byte_To_Hex(5, 4),
                Byte_To_Hex(9, 8),
                "0x" + Byte_To_Hex(17, 1),
                Byte_To_Hex_Reverse(18, 2, true),
                Byte_To_Hex(20, 7),
                Byte_To_Hex_Reverse(27, 4, false),
                Byte_To_Hex_Reverse(31, 4, true),
                Byte_To_Hex_Reverse(35, 4, true),
                Byte_To_Hex_Reverse(39, 4, true),
                Byte_To_Hex_Reverse(43, 4, true),
                Byte_To_Hex_Reverse(47, 4, true),
                Byte_To_Hex(51, 1),
                Byte_To_Hex(52, 1),
                "0x" + Byte_To_Hex(53, 10),
                "0x" + Byte_To_Hex(63, 1),
                "0x" + Byte_To_Hex(64, 1),
                Byte_To_Hex_Reverse(65, 2, true),
                Byte_To_Hex_Reverse(67, 2, true),
                Byte_To_Hex_Reverse(69, 2, true),
                Byte_To_Hex_Reverse(71, 2, true),
                Byte_To_Hex_Reverse(73, 2, true),
                Byte_To_Hex(75, 1),
                Byte_To_Hex_Reverse(76, 2, true),
                Byte_To_Hex_Reverse(78, 2, true),
                Byte_To_Hex(80, 1),
                Byte_To_Hex_Reverse(81, 2, true),
                Byte_To_Hex_Reverse(83, 2, true),
                Byte_To_Time(85, 4, true),
                Byte_To_Time(89, 4, true),
                Byte_To_Time(93, 4, true),
                Byte_To_Time(97, 4, true),
                Byte_To_Time(101, 4, true),
                "0x" + Byte_To_Hex(105, 1),
                "0x" + Byte_To_Hex(106, 1),
                "0x" + Byte_To_Hex(107, 1),
                "0x" + Byte_To_Hex(108, 1),
                Byte_To_Time(109, 4, true),
                Byte_To_Hex_Reverse(113, 2, true),
                Byte_To_Hex_Reverse(115, 2, true),
                Byte_To_Hex_Reverse(117, 2, true),
                Byte_To_Hex_Reverse(119, 2, true),
                "0x" + Byte_To_Hex(121, 1),
                "0x" + Byte_To_Hex(122, 1),
                Byte_To_Hex_Reverse(123, 2, true),
                Byte_To_Char_To_String(125, 8),
                Byte_To_Char_To_String(133, 10),
                Byte_To_Char_To_String(143, 6),
                Byte_To_Hex_Reverse(149, 2, true),
                "0x" + Byte_To_Hex(151, 1),
                "0x" + Byte_To_Hex(152, 1),
                Byte_To_Hex_Reverse(153, 2, true),
                Byte_To_Hex_Reverse(155, 2, true),
                Byte_To_Hex_Reverse(157, 2, true),
                Byte_To_Hex_Reverse(159, 2, true),
                "0x" + Byte_To_Hex(161, 1),
                "0x" + Byte_To_Hex(162, 1),
                Byte_To_Hex_Reverse(163, 2, true),
                Byte_To_Hex_Reverse(165, 2, true),
                Byte_To_Hex_Reverse(167, 2, true),
                Byte_To_Hex_Reverse(169, 4, true),
                Byte_To_Hex_Reverse(173, 4, false),
                Byte_To_Hex_Reverse(177, 2, true),
                Byte_To_Hex(179, 1),
                Byte_To_Hex_Reverse(180, 2, true),
                Byte_To_Hex_Reverse(182, 2, true),
                "0x" + Byte_To_Hex(184, 1),
                Byte_To_Time(185, 4, true),
                Byte_To_Time(189, 4, true),
                Byte_To_Hex(193, 1),
                Byte_To_Hex_Reverse(194, 4, true),
                "0x" + Byte_To_Hex_Reverse(198, 1, false),
                Byte_To_Time(199, 4, true),
                Byte_To_Time(203, 4, true),
                Byte_To_Time(207, 4, true),
                Byte_To_Hex_Reverse(211, 2, true),
                Byte_To_Hex_Reverse(213, 2, true),
                Byte_To_Hex_Reverse(215, 2, true),
                "0x" + Byte_To_Hex(217, 35),
                "0x" + Byte_To_Hex(252, 4),
            };
            Printdata(datas);
            LogChange(256);
            if (log.Length == 0) break;
        }
    }

    private void IPASS(string path) {
        File_To_Log(path);
        LogChange(434);

        while (true) {
            string[] datas = new string[] {
                Byte_To_Char_To_String(0, 1),
                Byte_To_Char_To_String(1, 6),
                Byte_To_Char_To_String(7, 1),
                Byte_To_Char_To_String(8, 4),
                Byte_To_Char_To_String(12, 4),
                Byte_To_Char_To_String(16, 4),
                Byte_To_Char_To_String(20, 8),
                Byte_To_Char_To_String(28, 6),
                Byte_To_Char_To_String(34, 2),
                Byte_To_Char_To_String(36, 4),
                Byte_To_Char_To_String(40, 4),
                Byte_To_Char_To_String(44, 1),
                Byte_To_Char_To_String(45, 1),
                Byte_To_Char_To_String(46, 12),
                Byte_To_Char_To_String(58, 12),
                Byte_To_Char_To_String(70, 12),
                Byte_To_Char_To_String(82, 3),
                Byte_To_Char_To_String(85, 32),
                Byte_To_Char_To_String(117, 6),
                Byte_To_Char_To_String(123, 3),
                Byte_To_Char_To_String(126, 12),
                Byte_To_Char_To_String(138, 8),
                Byte_To_Char_To_String(146, 6),
                Byte_To_Char_To_String(152, 4),
                Byte_To_Char_To_String(156, 4),
                Byte_To_Char_To_String(160, 4),
                Byte_To_Char_To_String(164, 4),
                Byte_To_Char_To_String(168, 4),
                Byte_To_Char_To_String(172, 2),
                Byte_To_Char_To_String(174, 3),
                Byte_To_Char_To_String(177, 3),
                Byte_To_Char_To_String(180, 2),
                Byte_To_Char_To_String(182, 4),
                Byte_To_Char_To_String(186, 6),
                Byte_To_Char_To_String(192, 8),
                Byte_To_Char_To_String(200, 8),
                Byte_To_Char_To_String(208, 8),
                Byte_To_Char_To_String(216, 4),
                Byte_To_Char_To_String(220, 4),
                Byte_To_Char_To_String(224, 4),
                Byte_To_Char_To_String(228, 8),
                Byte_To_Char_To_String(236, 12),
                Byte_To_Char_To_String(248, 16),
                Byte_To_Char_To_String(264, 1),
                Byte_To_Char_To_String(265, 2),
                Byte_To_Char_To_String(267, 3),
                Byte_To_Char_To_String(270, 3),
                Byte_To_Char_To_String(273, 68),
                Byte_To_Char_To_String(341, 8),
            };
            Printdata(datas);
            LogChange(352);
            if (log.Length < 352) break;
        }
    }

    private void S1S2(string path) {
        File_To_Log(path);
        LogChange(12);

        while (true) {
            string[] datas = new string[] {
                log[0].ToString(),
                log[1].ToString(),
                log[2].ToString(),
                Byte_To_Hex_Reverse(3, 3, false),
                log[6].ToString(),
                Byte_To_Time(7, 4, true),
                Byte_To_Hex_Reverse(11, 7, true),
                log[18].ToString(),
                log[19].ToString(),
                Byte_To_Hex_Reverse(20, 3, true),
                Byte_To_Hex_Reverse(23, 3, true),
                log[26].ToString(),
                log[27].ToString(),
                Byte_To_Hex_Reverse(28, 3, true),
                Byte_To_Hex_Reverse(31, 6, false),
                Byte_To_Hex_Reverse(37, 3, true),
                Byte_To_Hex_Reverse(40, 2, true),
                log[42].ToString(),
                log[43].ToString(),
                log[44].ToString(),
                log[45].ToString(),
                Byte_To_Hex(46, 8),
                Byte_To_Hex_To_Int(54, 3),
                Byte_To_Hex(57, 1),
                Byte_To_Hex(58, 2),
                Byte_To_Hex_To_Int(60, 3),
                Byte_To_Hex_Reverse(63, 3, true),
                Byte_To_Hex_To_Int(66, 1),
                "0x" + Byte_To_Hex(67, 1),
                "0x" + Byte_To_Hex(68, 2),
                Byte_To_Hex_Reverse(70, 3, true),
                Byte_To_Hex_To_Int(73, 1),
                Byte_To_Hex_Reverse(74, 3, true),
                Byte_To_Hex_Reverse(77, 3, true),
                Byte_To_Hex_Reverse(80, 3, true),
                Byte_To_Hex_Reverse(83, 3, true),
                Byte_To_Hex_Reverse(86, 3, true),
                Byte_To_Hex_Reverse(89, 3, true),
                Byte_To_Hex_To_Int(92, 3),
                Byte_To_Hex_Reverse(95, 2, true),
                Byte_To_Hex_Reverse(97, 2, true),
                Byte_To_Hex_Reverse(99, 2, true),
                Byte_To_Hex_Reverse(101, 2, true),
                Byte_To_Hex_Reverse(103, 1, true),
                Byte_To_Hex_Reverse(104, 2, true),
                Byte_To_Hex_Reverse(106, 1, true),
                "0x" + Byte_To_Hex(107, 1),
                Byte_To_Hex_Reverse(108, 1, true),
                Byte_To_Char_To_String(109, 10),
                Byte_To_Hex_Reverse(119, 2, true),
                "0x" + Byte_To_Hex(121, 1),
                Byte_To_Time(122, 4, true),
                Byte_To_Hex_Reverse(126, 2, true),
                Byte_To_Time(128, 4, true),
                Byte_To_Hex_Reverse(132, 2, true),
                Byte_To_Hex_Reverse(134, 6, false),
                Byte_To_Hex_Reverse(140, 3, false),
                Byte_To_Hex_Reverse(143, 3, true),
                Byte_To_Hex_To_Int(146, 1),
                Byte_To_String(147, 12),
                log[159].ToString(),
                log[160].ToString(),
                Byte_To_Hex_To_Int(161, 2),
                Byte_To_Hex_To_Int(163, 2),
                Byte_To_Hex_To_Int(165, 2),
                Byte_To_Hex_To_Int(167, 2),
                log[169].ToString(),
                Byte_To_String(172, 4),
                log[176].ToString(),
                Byte_To_Hex(177, 1),
                Byte_To_Hex(178, 1),
                Byte_To_Hex(179, 1),
                Byte_To_Hex(180, 16),
                "0x" + Byte_To_Hex(196, 1),
                "0x" + Byte_To_Hex(197, 1),
                Byte_To_Hex_To_Int(198, 4),
                Byte_To_Hex_To_Int(202, 4),
                Byte_To_Hex(206, 8),
                Byte_To_Hex(214, 1),
                Byte_To_Hex(215, 1),
                Byte_To_Hex(216, 16),
            };
            Printdata(datas);
            LogChange(232);
            if (log.Length < 232) break;
        }
    }

    #region Mine

    private string Byte_To_String(int index, int length) {
        StringBuilder sb = new StringBuilder();
        for (int i = index ; i < index + length ; i++) {
            sb.Append(log[i].ToString());
        }
        return sb.ToString();
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

    private string Byte_To_Hex_Reverse(int index, int length, bool toint) {
        StringBuilder sb = new StringBuilder();
        for (int i = index + length - 1 ; i >= index ; i--) {
            sb.Append(Byte_To_Hex(i, 1));
        }
        if (toint)
            return Convert.ToUInt32(sb.ToString(), 16).ToString();
        else
            return sb.ToString();
    }

    private string Byte_To_Hex_To_Int(int index, int length) {
        return Convert.ToUInt32(Byte_To_Hex(index, length), 16).ToString();
    }

    private string Byte_To_Time(int index, int length, bool ifreverse) {
        long time;
        if (ifreverse)
            time = long.Parse(Byte_To_Hex_Reverse(index, length, true));
        else
            time = long.Parse(Byte_To_Hex_To_Int(index, length));

        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0);
        origin = origin.AddSeconds(time);
        return origin.ToString("yyyy/MM/dd HH:mm:ss");
    }

    private void File_To_Log(string path) {
        FileStream reader = new FileStream(path, FileMode.Open);
        log = new byte[(int)reader.Length];
        reader.Read(log, 0, (int)reader.Length);
        reader.Close();
    }

    private void LogChange(int datalength) {
        log_temp = new byte[log.Length - datalength];
        Array.Copy(log, datalength, log_temp, 0, log.Length - datalength);
        log = log_temp;
    }

    private void Printdata(string[] datas) {
        foreach (string data in datas) {
            Console.WriteLine(data);
        }
        Console.WriteLine("----------------------------------------------------------------------------");
    }

    #endregion
    
    #region Example

    private String byte_convert_unix_date_time(int index, int length, bool LSB = false) {

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

    private byte[] change_hlbyte(byte[] byte_temp) {
        byte[] byte_convert = new byte[byte_temp.Length];

        int j = 0;
        for (int i = byte_temp.Length - 1; i >= 0; i--)
        {
            byte_convert[j] = byte_temp[i];
            j++;
        }

        return byte_convert;
    }

    private String byte_to_hex_string(int index, int length, bool LSB = false) {
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

    private uint byte_to_hex_string_to_hex(int index, int length, bool LSB = false) {
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

    private String rfu_format(int index, int length, bool LSB = false) {
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