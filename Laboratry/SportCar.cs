using System;
using System.Drawing;

namespace Laboratry
{
    /// <summary>
    /// Класс отрисовки гоночного автомобиля
    /// </summary>
    public class SportCar : Car
    {
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия переднего спойлера
        /// </summary>
        public bool FrontSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия боковых спойлеров
        /// </summary>
        public bool SideSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия заднего спойлера
        /// </summary>
        public bool BackSpoiler { private set; get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>
        public SportCar(int maxSpeed, float weight, Color mainColor, Color dopColor, bool frontSpoiler, bool sideSpoiler, bool backSpoiler) :
        base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            FrontSpoiler = frontSpoiler;
            SideSpoiler = sideSpoiler;
            BackSpoiler = backSpoiler;
        }
        public SportCar(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 7)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                FrontSpoiler = Convert.ToBoolean(strs[4]);
                BackSpoiler = Convert.ToBoolean(strs[5]);
                SideSpoiler = Convert.ToBoolean(strs[6]);
            }
        }
        public override void DrawCar(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            // отрисуем сперва передний спойлер автомобиля (чтобы потом отрисовка автомобиля на него "легла")
            if (FrontSpoiler)
            {
                g.DrawEllipse(pen, _startPosX + 80, _startPosY - 6, 20, 20);
                g.DrawEllipse(pen, _startPosX + 80, _startPosY + 35, 20, 20);
                g.DrawEllipse(pen, _startPosX - 5, _startPosY - 6, 20, 20);
                g.DrawEllipse(pen, _startPosX - 5, _startPosY + 35, 20, 20);
                g.DrawRectangle(pen, _startPosX + 80, _startPosY - 6, 15, 15);
                g.DrawRectangle(pen, _startPosX + 80, _startPosY + 40, 15, 15);
                g.DrawRectangle(pen, _startPosX, _startPosY - 6, 14, 15);
                g.DrawRectangle(pen, _startPosX, _startPosY + 40, 14, 15);
                Brush spoiler = new SolidBrush(DopColor);
                g.FillEllipse(spoiler, _startPosX + 80, _startPosY - 5, 20, 20);
                g.FillEllipse(spoiler, _startPosX + 80, _startPosY + 35, 20, 20);
                g.FillRectangle(spoiler, _startPosX + 75, _startPosY, 25, 40);
                g.FillRectangle(spoiler, _startPosX + 80, _startPosY - 5, 15, 15);
                g.FillRectangle(spoiler, _startPosX + 80, _startPosY + 40, 15, 15);
                g.FillEllipse(spoiler, _startPosX - 5, _startPosY - 5, 20, 20);
                g.FillEllipse(spoiler, _startPosX - 5, _startPosY + 35, 20, 20);
                g.FillRectangle(spoiler, _startPosX - 5, _startPosY, 25, 40);
                g.FillRectangle(spoiler, _startPosX, _startPosY - 5, 15, 15);
                g.FillRectangle(spoiler, _startPosX, _startPosY + 40, 15, 15);
            }
            // и боковые
            if (SideSpoiler)
            {
                g.DrawRectangle(pen, _startPosX + 25, _startPosY - 6, 39, 10);
                g.DrawRectangle(pen, _startPosX + 25, _startPosY + 45, 39, 10);
                Brush spoiler = new SolidBrush(DopColor);
                g.FillRectangle(spoiler, _startPosX + 25, _startPosY - 5, 40, 10);
                g.FillRectangle(spoiler, _startPosX + 25, _startPosY + 45, 40, 10);
            }
            // теперь отрисуем основной кузов автомобиля
            base.DrawCar(g);
            // рисуем гоночные полоски
            SolidBrush br = new SolidBrush(DopColor);
            g.FillRectangle(br, _startPosX + 65, _startPosY + 15, 25, 5);
            g.FillRectangle(br, _startPosX + 65, _startPosY + 30, 25, 5);
            g.FillRectangle(br, _startPosX + 25, _startPosY + 15, 35, 5);
            g.FillRectangle(br, _startPosX + 25, _startPosY + 30, 35, 5);
            g.FillRectangle(br, _startPosX, _startPosY + 15, 20, 5);
            g.FillRectangle(br, _startPosX, _startPosY + 30, 20, 5);
            // рисуем задний спойлер автомобиля
            if (BackSpoiler)
            {
                Brush spoiler = new SolidBrush(DopColor);
                g.FillRectangle(spoiler, _startPosX - 5, _startPosY, 10, 50);
                g.DrawRectangle(pen, _startPosX - 5, _startPosY, 10, 50);
            }
        }
        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }
        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + FrontSpoiler + ";" + SideSpoiler + ";" + BackSpoiler;
        }
    }
}
