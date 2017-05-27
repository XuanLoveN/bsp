using BSP.Caching;
using BSP.Core;
using Ninject;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace BSP.Mvc.Controllers
{
    public class CaptchaController : Controller
    {
        [Inject, Named(CacheTypes.SESSION)]
        private ICache SessionCache { get; set; }

        public ActionResult Index(int length = 4, int width = 100, int height = 25)
        {
            //1. 生成随机字符串
            string randomString = TextUtility.GetRandomString(length, true, true, true);
            //2. 向会话中保存随机字符串
            SessionCache.Set("Captcha", randomString);
            //3. 绘制随机字符案串图像
            //!创建图像对象
            Bitmap image = new Bitmap(width, height);
            //!创建绘制工具
            Graphics g = Graphics.FromImage(image);

            //!定义强随机类型对象
            byte[] buffer = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(buffer);
            int seed = BitConverter.ToInt32(buffer, 0);
            Random rand = new Random(seed);

            //!字体数组
            string[] fonts = { "IrisUPC Bold", "Agency FB Bold", "Arial Rounded MT Bold", "Algerian", "Arial Black" };
            //!颜色数组
            Color[] colors = { Color.Black, Color.Red, Color.Blue, Color.Brown, Color.Green };

            //!设置过渡画刷
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                  colors[rand.Next(0, colors.Length)], colors[rand.Next(0, colors.Length)], 1.2f, true);

            try
            {
                //!将图片背景设置为白色
                g.Clear(Color.FromArgb(238, 238, 238));
                //3.1 绘制背景干扰线
                for (int i = 0; i < 10; i++)
                {
                    Pen linePen = new Pen(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 2));
                    //!x1,y1代表开始点的x轴y轴
                    int x1 = rand.Next(image.Width);
                    int y1 = rand.Next(image.Height);
                    int x2 = rand.Next(image.Width);
                    int y2 = rand.Next(image.Height);

                    g.DrawLine(linePen, x1, y1, x2, y2);
                }
                //3.2 绘制随机字符串
                for (int i = 0; i < length; i++)
                {
                    //!获取当前循环到的字符
                    string currentString = randomString[i].ToString();
                    //!获取字体样式
                    FontStyle[] fontStyles = { FontStyle.Regular, FontStyle.Bold, FontStyle.Italic, FontStyle.Bold | FontStyle.Italic };
                    FontStyle currentFontStyle = fontStyles[rand.Next(0, fontStyles.Length)];
                    //!获取当前文本字体
                    int fontSize = rand.Next(15, 18);
                    Font font = new Font(fonts[rand.Next(0, fonts.Length)], fontSize, currentFontStyle);
                    //!计算当前文本绘制大小
                    SizeF size = g.MeasureString(currentString, font);

                    //!计算文本出现的x轴、y轴坐标
                    int[] xArr = { width / length * i, width / length * (i + 1) - (int)size.Width };
                    float x = rand.Next(xArr.Min(), xArr.Max());
                    float y = rand.Next(0, 5);
                    //!绘制文本
                    g.DrawString(currentString, font, brush, x, y);
                }
                //3.3 绘制前端噪点
                for (int i = 0; i < 20; i++)
                {
                    int x = rand.Next(width);
                    int y = rand.Next(height);

                    Pen pen = new Pen(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 2));
                    int radius = rand.Next(1, 3);

                    g.DrawEllipse(pen, x, y, radius, radius);
                }

                //!绘制边框线
                //g.DrawRectangle(new Pen(Color.Blue, 1), 0, 0, width - 1, height - 1);

                //4. 将图像保存在内存中
                MemoryStream memory = new MemoryStream();
                image.Save(memory, ImageFormat.Jpeg);
                //5. 响应图像到视图中
                return File(memory.ToArray(), "image/jpeg");
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        /// <summary>
        /// 检查验证码动作方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Check(string id)
        {
            string validateCode = SessionCache.Get<string>("Captcha");

            if (string.IsNullOrEmpty(validateCode) || string.IsNullOrEmpty(id))
                return Json("验证码获取失败", JsonRequestBehavior.AllowGet);

            if (string.Equals(validateCode, id, StringComparison.CurrentCultureIgnoreCase))
                return Json(true, JsonRequestBehavior.AllowGet);

            return Json("验证码输入错误", JsonRequestBehavior.AllowGet);
        }
    }
}
