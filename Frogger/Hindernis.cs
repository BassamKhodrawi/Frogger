using System.Drawing;

namespace Frogger
{
    /// <summary>
    /// Diese Klasse beinhaltet ein Rechteck und weitere Felder, zur Darstellung eines Hindernisses.
    /// </summary>
    public class Hindernis
    {
        private Rectangle hitbox;
        private int speed;
        private Color color;
        private SolidBrush brush;

        public Hindernis(int x, int y, int width, int height, int speed, Color color)
        {
            this.hitbox = new Rectangle(x, y, width, height);
            this.speed = speed;

            // Damit man Zeichenmittel nutzen kann, muss System.Drawing importiert werden (oben bei using...)
            this.color = color;
            this.brush = new SolidBrush(color);
        }

        /// <summary>
        /// Zugriff auf die X-Eigenschaft des beinhalteten Rechtecks
        /// </summary>
        public int X
        {
            get { return hitbox.X; }
        }
        public int Y
        {
            get { return hitbox.Y; }
        }

        public int Width
        {
            get { return hitbox.Width; }
        }
        public int Height
        {
            get { return hitbox.Height; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }


        public void Move()
        {
            hitbox.X  = hitbox.X - Speed;
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public SolidBrush Brush
        {
            get { return brush; }
            set { brush = value; }
        }
    }
}
