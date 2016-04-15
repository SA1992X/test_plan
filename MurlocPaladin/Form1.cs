using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MurlocPaladin
{
    public partial class MurlocPaladin : Form
    {
        public MurlocPaladin()
        {
            InitializeComponent();
        }

        private void btnThatsAwesome_Click(object sender, EventArgs e)
        {
            int OldMurk_Eye = 0;
            int Warleader = 0;
            int BluegillWarrior = 0;
            int GrimscaleOracle = 0;
            int NoFish = 0;
            int OldMurk_Eye2 = 0;
            int Warleader2 = 0;
            int BluegillWarrior2 = 0;
            int GrimscaleOracle2 = 0;
            int NoFish2 = 0;
            int result = 0;
            int dmgOfOld = 0;
            int dmgOfWarrior = 0;
            if (int.TryParse(txtOldMurk_Eye.Text, out OldMurk_Eye) && int.TryParse(txtWarleader.Text, out Warleader) && int.TryParse(txtBluegillWarrior.Text, out BluegillWarrior) && int.TryParse(txtGrimscaleOracle.Text, out GrimscaleOracle) && int.TryParse(txtNoFish.Text, out NoFish)
                && int.TryParse(txtOldMurk_Eye2.Text, out OldMurk_Eye2) && int.TryParse(txtWarleader2.Text, out Warleader2) && int.TryParse(txtBluegillWarrior2.Text, out BluegillWarrior2) && int.TryParse(txtGrimscaleOracle2.Text, out GrimscaleOracle2) && int.TryParse(txtNoFish2.Text, out NoFish2))
            {
                if (OldMurk_Eye >= 0 && Warleader >= 0 && BluegillWarrior >= 0 && GrimscaleOracle >= 0 && NoFish >= 0
                    && OldMurk_Eye2 >= 0 && Warleader2 >= 0 && BluegillWarrior2 >= 0 && GrimscaleOracle2 >= 0 && NoFish2 >= 0)
                {
                    dmgOfWarrior += ((Warleader + Warleader2) * 2 + (GrimscaleOracle + GrimscaleOracle2) * 1 + 2) * BluegillWarrior;
                    dmgOfOld += ((Warleader + Warleader2) * 2 + (GrimscaleOracle + GrimscaleOracle2) * 1 + (Warleader + Warleader2) + (BluegillWarrior + BluegillWarrior2) + (GrimscaleOracle + GrimscaleOracle2) + (NoFish + NoFish2) + (OldMurk_Eye + OldMurk_Eye2 - 1) + 2) * OldMurk_Eye;
                    result = dmgOfOld + dmgOfWarrior;
                    lblResult.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("鱼人这个asasasdfsdfsfsdfds111！");
                }
            }
            else
            {
                MessageBox.Show("鱼人数目不对啊，你逗我！");
            }


        }

        private void reset()
        {
            txtOldMurk_Eye.Text = "0";
            txtWarleader.Text = "0";
            txtBluegillWarrior.Text = "0";
            txtGrimscaleOracle.Text = "0";
            lblResult.Text = "0";

            txtOldMurk_Eye2.Text = "0";
            txtWarleader2.Text = "0";
            txtBluegillWarrior2.Text = "0";
            txtGrimscaleOracle2.Text = "0";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        public void startCaculate()
        {
            int OldMurk_Eye = 0;
            int Warleader = 0;
            int BluegillWarrior = 0;
            int GrimscaleOracle = 0;
            int NoFish = 0;
            int OldMurk_Eye2 = 0;
            int Warleader2 = 0;
            int BluegillWarrior2 = 0;
            int GrimscaleOracle2 = 0;
            int NoFish2 = 0;
            if (int.TryParse(txtOldMurk_Eye.Text, out OldMurk_Eye) && int.TryParse(txtWarleader.Text, out Warleader) && int.TryParse(txtBluegillWarrior.Text, out BluegillWarrior) && int.TryParse(txtGrimscaleOracle.Text, out GrimscaleOracle) && int.TryParse(txtNoFish.Text, out NoFish)
               && int.TryParse(txtOldMurk_Eye2.Text, out OldMurk_Eye2) && int.TryParse(txtWarleader2.Text, out Warleader2) && int.TryParse(txtBluegillWarrior2.Text, out BluegillWarrior2) && int.TryParse(txtGrimscaleOracle2.Text, out GrimscaleOracle2) && int.TryParse(txtNoFish2.Text, out NoFish2))
            {
                List<OldMurk_Eye> oe = new List<OldMurk_Eye>(new OldMurk_Eye[OldMurk_Eye]);
                List<Warleader> wl = new List<Warleader>(new Warleader[Warleader]);
                List<BluegillWarrior> bw = new List<BluegillWarrior>(new BluegillWarrior[BluegillWarrior]);
                List<GrimscaleOracle> go = new List<GrimscaleOracle>(new GrimscaleOracle[GrimscaleOracle]);
                List<NoFish> nf = new List<NoFish>(new NoFish[NoFish]);

                MurlocList graveYard = new MurlocList();
                graveYard.OE = oe;
                graveYard.WL = wl;
                graveYard.BW = bw;
                graveYard.GO = go;
                graveYard.NF = nf;
            }
            else
                MessageBox.Show("鱼人数目不对啊，呜啦啦啦咕噜哇啦！");
        }
    }

   



    //老瞎眼
    public class OldMurk_Eye : minion
    {
        public OldMurk_Eye()
        {
            this.attack = 2;
            this.health = 4;
            this.isCharge = true;
        }
        public OldMurk_Eye(MurlocList oc)
        {
            this.attack = 5;
            this.health = 4;
            this.isCharge = true;
            buff(oc);
        }
        public override void buff(MurlocList oc)
        {
            if (oc.OE.Contains(this))
                this.attack = 2 + oc.BW.Count() + oc.GO.Count() + oc.NF.Count() + (oc.OE.Count() - 1) + oc.WL.Count();
            else
                this.attack = 2 + oc.BW.Count() + oc.GO.Count() + oc.NF.Count() + (oc.OE.Count()) + oc.WL.Count();
        }

    }
    //鱼人领军
    public class Warleader : minion
    {
        public Warleader()
        {
            this.attack = 3;
            this.health = 3;
            this.isCharge = false;
        }
        public Warleader(MurlocList oc)
        {
            this.attack = 3;
            this.health = 3;
            this.isCharge = false;
            buff(oc);
        }
        public override void buff(MurlocList oc)
        {
            foreach (minion m in oc.OE)
            {
                m.attackUp(2);
                m.healthUp(1);
            }
            foreach (minion m in oc.BW)
            {
                m.attackUp(2);
                m.healthUp(1);
            }
            foreach (minion m in oc.GO)
            {
                m.attackUp(2);
                m.healthUp(1);
            }
            foreach (minion m in oc.WL)
            {
                if (!m.ID.Equals(this.ID))
                {
                    m.attackUp(2);
                    m.healthUp(1);
                }
            }
            foreach (minion m in oc.NF)
            {
                m.attackUp(2);
                m.healthUp(1);
            }
        }
        public override void buffCancel(MurlocList oc)
        {
            foreach (minion m in oc.OE)
            {
                m.attackDown(2);
                m.healthDown(1);
            }
            foreach (minion m in oc.BW)
            {
                m.attackDown(2);
                m.healthDown(1);
            }
            foreach (minion m in oc.GO)
            {
                m.attackDown(2);
                m.healthDown(1);
            }
            foreach (minion m in oc.WL)
            {
                m.attackDown(2);
                m.healthDown(1);
            }
            foreach (minion m in oc.NF)
            {
                m.attackDown(2);
                m.healthDown(1);
            }
        }
    }
    //蓝腮战士
    public class BluegillWarrior : minion
    {
        public BluegillWarrior()
        {
            this.attack = 2;
            this.health = 1;
            this.isCharge = true;
        }
        public BluegillWarrior(MurlocList oc)
        {
            this.attack = 2;
            this.health = 1;
            this.isCharge = true;
        }
        public override void buff(MurlocList oc)
        {

        }
        public override void buffCancel(MurlocList oc)
        {

        }
    }
    //暗鳞先知
    public class GrimscaleOracle : minion {
        public GrimscaleOracle() {
            this.attack = 1;
            this.health = 1;
            this.isCharge = false;
        }
        public GrimscaleOracle(MurlocList oc)
        {
            this.attack = 1;
            this.health = 1;
            this.isCharge = false;
        }
        public override void buff(MurlocList oc)
        {
            foreach (minion m in oc.OE)
            {
                m.attackUp(1);
            }
            foreach (minion m in oc.BW)
            {
                m.attackUp(1);
            }
            foreach (minion m in oc.GO)
            {
                if(!m.ID.Equals(this.ID))
                m.attackUp(1);
            }
            foreach (minion m in oc.WL)
            {
                m.attackUp(1);
            }
            foreach (minion m in oc.NF)
            {
                m.attackUp(1);
            }
        }

        public override void buffCancel(MurlocList oc)
        {
            foreach (minion m in oc.OE)
            {
                m.attackDown(1);
            }
            foreach (minion m in oc.BW)
            {
                m.attackDown(1);
            }
            foreach (minion m in oc.GO)
            {
                if (!m.ID.Equals(this.ID))
                    m.attackDown(1);
            }
            foreach (minion m in oc.WL)
            {
                m.attackDown(1);
            }
            foreach (minion m in oc.NF)
            {
                m.attackDown(1);
            }
        }
    }
    //杂牌军
    public class NoFish : minion { }

    //随从基础数据
    public class minion
    {
        public string ID = Guid.NewGuid().ToString();
        //攻击
        public int attack { get; set; }
        //血量
        public int health { get; set; }
        //冲锋
        public bool isCharge { get; set; }
        //战吼
        public virtual void battleCry(MurlocList oc) { }
        //buff
        public virtual void buff(MurlocList oc) { }
        public virtual void buffCancel(MurlocList oc) { }
        //亡语
        public virtual void deathRattle(MurlocList oc) { }
        //攻击力改变
        public void attackUp(int i)
        {
            this.attack += i;
        }
        public void attackDown(int i)
        {
            if (this.attack <= i)
                this.attack = 0;
            else
                this.attack += -i;
        }
        //生命值改变
        public void healthUp(int i)
        {
            this.health += i;
        }
        public void healthDown(int i)
        {
            if (this.health <= i)
                this.health = 0;
            else
                this.health += -i;
        }
    }

    //鱼人列表
    public class MurlocList
    {
        public List<OldMurk_Eye> OE = new List<OldMurk_Eye>();
        public List<Warleader> WL = new List<Warleader>();
        public List<BluegillWarrior> BW = new List<BluegillWarrior>();
        public List<GrimscaleOracle> GO = new List<GrimscaleOracle>();
        public List<NoFish> NF = new List<NoFish>();
    }
}
