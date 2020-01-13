using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace AoteNiu
{
    public static partial class CommonHelper
    {
        /// <summary>
        /// 加载配置文件，构建IConfigurationRoot
        /// </summary>
        private static readonly IConfigurationBuilder ConfigurationBuilder = new ConfigurationBuilder();

        /// <summary>
        /// 获取配置文件中的内容，继承自IConfiguration
        /// </summary>
        private static IConfigurationRoot _AppSettingconfiguration;
        private static IConfigurationRoot _AppErrorInfoconfiguration;
        private static IConfigurationRoot _AppStringInfoconfiguration;

        public static List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        public static T GetAppSetting<T>(string section, string key, T defValue = default(T))
        {
            Guard.ArgumentNotEmpty(() => section);
            Guard.ArgumentNotEmpty(() => key);

            if (null == _AppSettingconfiguration)
            {
                _AppSettingconfiguration = ConfigurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(cfg =>
                {
                    cfg.Path = "appsettings.json";
                    cfg.ReloadOnChange = true;
                    cfg.Optional = false;
                })
                //Build方法的调用要在AddJsonFile之后，否则生成的IConfigurationRoot实例的
                //Providers属性不包含任何元素而导致无法读取文件中的信息
                .Build();
            }

            var setting = _AppSettingconfiguration.GetSection(section)[key];
            if (setting == null)
            {
                return defValue;
            }

            return setting.Convert<T>();
        }

        public static T GetAppSettingSingle<T>(string full, T defValue = default(T))
        {
            Guard.ArgumentNotEmpty(() => full);

            if (null == _AppSettingconfiguration)
            {
                _AppSettingconfiguration = ConfigurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(cfg =>
                {
                    cfg.Path = "appsettings.json";
                    cfg.ReloadOnChange = true;
                    cfg.Optional = false;
                })
                //Build方法的调用要在AddJsonFile之后，否则生成的IConfigurationRoot实例的
                //Providers属性不包含任何元素而导致无法读取文件中的信息
                .Build();
            }

            var setting = _AppSettingconfiguration.GetSection(full).Value;
            if (setting == null)
            {
                return defValue;
            }

            return setting.Convert<T>();
        }

        /// <summary>
        /// 获取指定长度范围的随机字符串(数字 + 字母 + 特殊字符 + 特定字符)；
        /// </summary>
        public static string GenerateRandomString(
            int minLen, 
            int maxLen, 
            bool useNum = true, 
            bool useLow = true,
            bool useUpp = true, 
            bool useSpe = false, 
            string custom = null)
        {
            StringBuilder ConstStr = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(custom))
            {
                ConstStr.Append(custom);
            }

            if (useNum == true) 
            {
                ConstStr.Append("0123456789"); 
            }

            if (useLow == true) 
            { 
                ConstStr.Append("abcdefghijklmnopqrstuvwxyz"); 
            }
            
            if (useUpp == true) 
            { 
                ConstStr.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ"); 
            }

            if (useSpe == true) 
            { 
                ConstStr.Append("!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"); 
            }

            // 随机种子;
            byte[] b = new byte[4];

            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));

            StringBuilder RandStr = new StringBuilder(minLen, maxLen);

            int length = r.Next(minLen, maxLen);
            for (int i = 0; i < length; i++)
            {
                RandStr.Append(ConstStr[r.Next(ConstStr.Length - 1)]);
            }

            return RandStr.ToString();
        }

        /// <summary>
        /// 微信支付专用随机串
        /// </summary>
        /// <returns></returns>
        public static string GenerateWeChatNonStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// 获取指定长度随机数字码；
        /// </summary>
        public static string GenerateRandomDigitCode(int length)
        {
            var random = new Random();

            string str = string.Empty;

            for (int i = 0; i < length; i++)
            {
                str = String.Concat(str, random.Next(10).ToString());
            }

            return str;
        }

        /// <summary>
        /// 获取指定范围随机数；
        /// </summary>
        public static int GenerateRandomInteger(int min = 0, int max = 2147483647)
        {
            var randomNumberBuffer = new byte[10];
            new RNGCryptoServiceProvider().GetBytes(randomNumberBuffer);
            return new Random(BitConverter.ToInt32(randomNumberBuffer, 0)).Next(min, max);
        }

        /// <summary>
        /// 生成随机日期时间
        /// </summary>
        /// <param name="sday">开始日期</param>
        /// <param name="eday">结束日期</param>
        /// <param name="shour">开始小时</param>
        /// <param name="ehour">结束小时</param>
        /// <returns></returns>
        public static DateTime GenerateRandomDateTime(DateTime sday, DateTime eday, int shour, int ehour)
        {
            if (shour <= 0)
            {
                shour = 8;
            }
            
            if (ehour <= 0 || ehour >= 24)
            {
                ehour = 22;
            }

            int interval = (int)(eday - sday).TotalDays;
            if (interval < 1)
	        {
		        interval = 1;
	        }

            var days = CommonHelper.GenerateRandomInteger(1, interval);

            var randay = sday.AddDays(days - 1);
            
            int hours = CommonHelper.GenerateRandomInteger(shour, ehour);
            int minutes = CommonHelper.GenerateRandomInteger(1, 59);
            int seconds = CommonHelper.GenerateRandomInteger(1, 59);

            var dt = new DateTime(randay.Year, randay.Month, randay.Day, hours, minutes, seconds, 0);

            return dt;
        }

        /// <summary>
        /// 根据手机生成默认昵称
        /// </summary>
        /// <returns></returns>
        public static string GenerateNickNameByPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Trim().Length != 11)
            {
                return string.Empty;
            }

            /// 中间四位改成****
            var sb = new StringBuilder();

            sb.Append(phone.Substring(0, 3));
            sb.Append("****");
            sb.Append(phone.Substring(7, 4));

            return sb.ToString();
        }

        /// <summary>
        /// 字符串马赛克
        /// </summary>
        /// <returns></returns>
        public static string MosaicString(string info, char msk = '*')
        {
            if (string.IsNullOrWhiteSpace(info) || info.Trim().Length < 2)
            {
                return string.Empty;
            }

            /// 中间四位改成****
            var sb = new StringBuilder();

            sb.Append(info.FirstOrDefault());
            sb.Append("****");
            sb.Append(info.LastOrDefault());

            return sb.ToString();
        }

        /// <summary>
        /// 获取指定长度字符串，超出部分省略号
        /// </summary>
        /// <returns></returns>
        public static string TripString(string info, int length)
        {
            if (!info.HasValue())
            {
                return string.Empty;
            }

            var str = info.Trim();
            if (str.Length > length)
            {
                return str.Substring(0, length) + "...";
            }

            return str;
        }

        /// <summary>
        /// 获取当前double类型值的小数点位数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetDoubleDecimals(double value)
        {
            var svalues = value.ToString().Split('.');
            if (svalues.Length != 2)
            {
                return 0;
            }

            return svalues[1].Length;
        }

        /// <summary>
        /// Create salt key
        /// </summary>
        /// <param name="size">Key size</param>
        /// <returns>Salt key</returns>
        public static string CreateSaltKey(int size = 5)
        {
            // Generate a cryptographic random number
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        /// <summary>
        /// Create a password hash(二次加密)
        /// </summary>
        /// <param name="password">MD5加密后的password</param>
        /// <param name="salt">Salk key</param>
        /// <param name="passwordFormat">Password format (hash algorithm)</param>
        /// <returns>Password hash</returns>
        public static string CreatePasswordHash(string password, string salt, string passwordFormat = "MD5", int hashTimes = 128)
        {
            // 计算哈希值
            var algorithm = HashAlgorithm.Create(passwordFormat);

            byte[] saltPasswordValue = UTF8Encoding.UTF8.GetBytes(String.Concat(salt, password));
            saltPasswordValue = algorithm.ComputeHash(saltPasswordValue);

            // 因为上面计算了一次hash, 所以只需要迭代 N-1 次
            for (int i = 0; i < hashTimes - 1; i++)
            {
                saltPasswordValue = algorithm.ComputeHash(saltPasswordValue);
            }

            return BitConverter.ToString(saltPasswordValue).Replace("-", "").ToLower();
        }

        public static string CreateBtchatPhash(string password)
        {
            var bytes = Encoding.ASCII.GetBytes(password);
            string pHash = GetSha1Encrypt($"{password}{Convert.ToBase64String(bytes)}");

            return pHash;
        }

        public static string GetSha1Encrypt(string string4Encrypt)
        {
            var algorithm = HashAlgorithm.Create("SHA1");
            if (algorithm == null)
            {
                throw new ArgumentException("Unrecognized hash name", "hashName");
            }

            var hashByteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(string4Encrypt));
            return BitConverter.ToString(hashByteArray).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 检测是否含有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasChinese(string inputData)
        {
            var RegCHZN = new System.Text.RegularExpressions.Regex("[\u4e00-\u9fa5]");

            var m = RegCHZN.Match(inputData);
            return m.Success;
        }

        public static string GetMd5_16(this string inputStr, Encoding encoding = null)
        {
            if (null == encoding)
            {
                encoding = Encoding.UTF8;
            }

            var md5 = new MD5CryptoServiceProvider();
            var t2 = BitConverter.ToString(md5.ComputeHash(encoding.GetBytes(inputStr)), 4, 8);
            t2 = t2.Replace("-", "");

            return t2;
        }

        /// <summary>  
        /// 获取32位长度的Md5摘要  
        /// </summary>  
        /// <param name="inputStr"></param>  
        /// <param name="encoding"></param>  
        /// <returns></returns>  
        public static string GetMD5_32(this string inputStr, Encoding encoding = null)
        {
            if (null == encoding)
            {
                encoding = Encoding.UTF8;
            }

            StringBuilder tmp = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(encoding.GetBytes(inputStr));
                for (int i = 0; i < data.Length; i++)
                {
                    tmp.Append(data[i].ToString("x2"));
                }
            }

            return tmp.ToString();
        }

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <returns></returns>
        public static string GetFileExtension(string filename)
        {
            if (!filename.HasValue())
            {
                return "";
            }

            var pos = filename.LastIndexOf('.');
            if (-1 == pos)
            {
                return "";
            }

            return filename.Substring(pos);
        }

        /// <summary>
        /// 判断是否非法的mongodb 主键格式;
        /// 24位 小写 16进制串;
        /// </summary>
        /// <returns></returns>
        public static bool NonMongoId(string id)
        {
            // 非空；
            if (string.IsNullOrWhiteSpace(id))
            {
                return true;
            }

            // mongid 固定长度;
            if (id.Trim().Length != 24)
            {
                return true;
            }

            // 小写16进制串
            foreach (var c in id.ToCharArray())
            {
                if (char.IsDigit(c) && ('0' > c || '9' < c))
                {
                    return true;
                }

                if (char.IsLetter(c) && ('a' > c || 'f' < c))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 转行成显示显示格式；
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetShowTimeString(string time, string fromat)
        {
            DateTime t;

            if (17 != time.Length)
            {
                return string.Empty;
            }

            try
            {
                t = DateTime.ParseExact(time, AoteNiuConst.DATE_TIME_FOR_SOTRE, null);
            }
            catch (Exception)
            {
                return time;
            }

            return t.ToString(fromat);
        }

        /// <summary>
        /// 转换成字符串
        /// </summary>
        /// <param name="time"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ShowTime(DateTime time, string format)
        {
            if (time == DateTime.MinValue)
            {
                return string.Empty;
            }

            return time.ToString(format);
        }

        /// <summary>  
        /// Unix时间戳转为C#格式时间  
        /// </summary>  
        /// <param name="timeStamp">Unix时间戳格式,例如1482115779</param>  
        /// <returns>C#格式时间</returns>  
        public static DateTime Convert2DateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            long lTime = 0;
            if (timeStamp.ToString().Length >= 13)
            {
                lTime = long.Parse(timeStamp + "0000");
            }
            else
            {
                lTime = long.Parse(timeStamp + "0000000");
            }

            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>  
        /// DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time"> DateTime时间格式</param>  
        /// <returns>Unix时间戳格式</returns>  
        public static int Convert2UnixTimestamp(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 字符串解析成金额
        /// </summary>
        /// <param name="bvalue"></param>
        /// <returns></returns>
        public static string Convert2RMBValue(string bvalue)
        {
            if (string.IsNullOrWhiteSpace(bvalue))
            {
                return "0";
            }

            bvalue = bvalue.Trim();
            for (int i = 0; i < bvalue.Length; i++)
            {
                if (bvalue[i] != '.' && !char.IsDigit(bvalue[i]))
                {
                    return "0";
                }
            }

            var nbs = bvalue.Split('.');
            if (nbs.Length > 2)
            {
                return "0";
            }
            else if (nbs.Length == 2)
            {
                var real = $"{nbs[0]}.{nbs[1].Substring(0, nbs[1].Length >= 2 ? 2 : nbs[1].Length)}";
                return real == "0.00" ? "0" : real;
            }
            else if (nbs.Length == 1)
            {
                return bvalue == "0.00" ? "0" : bvalue;
            }

            return "0";
        }

        public static ErrorInfo GetRspInfo(ErrorInfo err)
        {
            Guard.ArgumentNotNull(() => err);

            if (null == _AppErrorInfoconfiguration)
            {
                _AppErrorInfoconfiguration = ConfigurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(cfg =>
                {
                    cfg.Path = "rspinfo.json";
                    cfg.ReloadOnChange = true;
                    cfg.Optional = false;
                })
                //Build方法的调用要在AddJsonFile之后，否则生成的IConfigurationRoot实例的
                //Providers属性不包含任何元素而导致无法读取文件中的信息
                .Build();
            }

            ErrorInfo rsp = new ErrorInfo();

            Console.WriteLine($"E{err.code}");
            _AppErrorInfoconfiguration.GetSection($"E{err.code}").Bind(rsp);
            if (rsp == null)
            {
                Console.WriteLine($"can not find E{err.code} in rspinfo.json !");
                return err;
            }

            return rsp;
        }

        public static string GetTranslateString(string key, string lang)
        {
            if (string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }

            if (null == _AppStringInfoconfiguration)
            {
                _AppStringInfoconfiguration = ConfigurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(cfg =>
                {
                    cfg.Path = "strings.json";
                    cfg.ReloadOnChange = true;
                    cfg.Optional = false;
                })
                //Build方法的调用要在AddJsonFile之后，否则生成的IConfigurationRoot实例的
                //Providers属性不包含任何元素而导致无法读取文件中的信息
                .Build();
            }

            TranslateInfo rsp = new TranslateInfo();

            _AppStringInfoconfiguration.GetSection(key).Bind(rsp);
            if (rsp != null)
            {
                lang = lang?.ToLower() ?? string.Empty;
                if (lang == Lang.Chinese || lang == Lang.Chinese_Simple)
                {
                    return rsp.zh;
                }
                else if (lang == Lang.Chinese_Traditional || lang == Lang.Chinese_TraditionalR)
                {
                    return rsp.zh_tw;
                }
                else if (lang == Lang.English)
                {
                    return rsp.en;
                }
            }

            return rsp.zh;
        }

        /// <summary>
        /// 参数去空格；
        /// </summary>
        /// <param name="bind"></param>
        public static void TrimStringOfBindModel(Object bind, bool trimall = false)
        {
            if (null == bind)
            {
                return;
            }

            var properties = bind.GetType().GetProperties();

            foreach (var p in properties)
            {
                if (p.PropertyType.Equals(typeof(string)))
                {
                    var value = p.GetValue(bind) as string;

                    // 去除所有空格：中英文
                    if (trimall)
                    {
                        p.SetValue(bind, (value == null ? null : value.Replace(" ", "").Replace(@" ", "")));
                    }
                    else
                    {
                        p.SetValue(bind, (value == null ? null : value.Trim()));
                    }
                }
            }
        }

        /// <summary>
        /// 统一double格式： 
        /// </summary>
        /// <param name="model"></param>
        public static void FormatDouble(Object model, int num)
        {
            if (null == model)
            {
                return;
            }

            var properties = model.GetType().GetProperties();

            foreach (var p in properties)
            {
                if (p.PropertyType.Equals(typeof(double)))
                {
                    var value = (double)(p.GetValue(model));

                    p.SetValue(model, Math.Round(value, num));
                }
            }
        }

        /// <summary>
        /// 大值数据格式化
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static string FormatBigAmount(decimal amount, int decimals, string lang)
        {
            var x = string.Empty;

            int bv = 1;
            string dv = string.Empty;

            decimal abs = Math.Abs(amount);
            if (lang == Lang.Chinese || lang == Lang.Chinese_Simple)
            {
                if (abs >= 100000000)
                {
                    bv = 100000000;
                    dv = "亿";
                }
                else if (abs >= 10000)
                {
                    bv = 10000;
                    dv = "万";
                }
                else
                {
                    bv = 1;
                }

                x = $"{Math.Round(abs / bv, decimals)}{dv}";
            }
            else if (lang == Lang.English)
            {
                if (abs >= 1000000000)
                {
                    bv = 1000000000;
                    dv = "B";
                }
                else if (abs >= 1000000)
                {
                    bv = 1000000;
                    dv = "M";
                }
                else if (abs >= 1000)
                {
                    bv = 1000;
                    dv = "K";
                }
                else
                {
                    bv = 1;
                }

                x = $"{Math.Round(abs / bv, decimals)}{dv}";
            }

            if (!string.IsNullOrEmpty(x))
            {
                x = (amount < 0 ? $"-{x}" : x);
            }

            return x;
        }

        /// <summary>
        /// 是否有效的 BigDecimal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsValidBigDecimal(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return false;
            }

            number = number.Trim();
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != '.' && !char.IsDigit(number[i]))
                {
                    return false;
                }
            }

            return true;
        }

        #region private

        /// <summary>
        /// 查找解决方案根路径;
        /// </summary>
        private static DirectoryInfo FindSolutionRoot(string currentDir)
        {
            var dir = Directory.GetParent(currentDir);
            while (true)
            {
                if (dir == null || IsSolutionRoot(dir))
                    break;

                dir = dir.Parent;
            }

            return dir;
        }

        /// <summary>
        /// 判断是否解决方案路径
        /// </summary>
        private static bool IsSolutionRoot(DirectoryInfo dir)
        {
            return File.Exists(Path.Combine(dir.FullName, "YunChiHuo.sln"));
        }

        #endregion

        #region convert

        public static bool TryConvert<T>(object value, out T convertedValue)
        {
            return TryConvert<T>(value, CultureInfo.InvariantCulture, out convertedValue);
        }

        public static bool TryConvert<T>(object value, CultureInfo culture, out T convertedValue)
        {
            return TryAction<T>(delegate
            {
                return value.Convert<T>(culture);
            }, out convertedValue);
        }

        public static bool TryConvert(object value, Type to, out object convertedValue)
        {
            return TryConvert(value, to, CultureInfo.InvariantCulture, out convertedValue);
        }

        public static bool TryConvert(object value, Type to, CultureInfo culture, out object convertedValue)
        {
            return TryAction<object>(delegate { return value.Convert(to, culture); }, out convertedValue);
        }

        private static bool TryAction<T>(Func<T> func, out T output)
        {
            Guard.ArgumentNotNull(() => func);

            try
            {
                output = func();
                return true;
            }
            catch
            {
                output = default(T);
                return false;
            }
        }

        #endregion
    }
}
