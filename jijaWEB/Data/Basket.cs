namespace jijaWEB.Data
{
    public class Basket
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _id_user;

        public int id_user
        {
            get { return _id_user; }
            set { _id_user = value; }
        }

        private int _id_goods;

        public int id_goods
        {
            get { return _id_goods; }
            set { _id_goods = value; }
        }

        private bool _condition;

        public bool condition
        {
            get { return _condition; }
            set { _condition = value; }
        }




    }
}
