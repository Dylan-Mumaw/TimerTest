using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimerTest
{
    public partial class TimerTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void btnEnterName_Click(object sender, EventArgs e)
        {
            // Player class will have instance variables for player name and number
            // and a bool for if it's their turn, which can be added to a list of players in Application state
            string playerName = txtName.Text;
            Session["playerName"] = playerName;
            int playerNumber = (int)Session["playerNumber"];

            List<bool> isTurn = new List<bool>();
            isTurn = (List<bool>)Application["isTurn"];
            int turnPlayer = getTurnPlayer();

            Label3.Text = "You are Player " + playerNumber + ": " + playerName;
            Label4.Text = "It is currently Player " + turnPlayer + "'s turn";

            if(playerNumber == turnPlayer)
            {
                TurnButton.Enabled = true;
            }

            pnlEnterName.Visible = false;
            pnlTurns.Visible = true;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.Second.ToString();
            Label2.Text = "Number of players online: " + Application["userCount"].ToString();
            int turnPlayer = getTurnPlayer();
            Label4.Text = "It is currently Player " + turnPlayer + "'s turn";

            if ((int)Session["playerNumber"] == turnPlayer)
            {
                TurnButton.Enabled = true;
            }
        }

        protected void TurnButton_Click(object sender, EventArgs e)
        {
            List<bool> isTurn = new List<bool>();
            isTurn = (List<bool>)Application["isTurn"];
            int turnPlayer = getTurnPlayer();
            isTurn[turnPlayer - 1] = false;
            if(isTurn.Count == turnPlayer)
            {
                isTurn[0] = true;
            }
            else
            {
                isTurn[turnPlayer] = true;
            }
            Application["isTurn"] = isTurn;
            TurnButton.Enabled = false;
        }

        int getTurnPlayer()
        {
            List<bool> isTurn = new List<bool>();
            isTurn = (List<bool>)Application["isTurn"];
            int turnPlayer = 0;

            for (int x = 0; x < isTurn.Count; x++)
            {
                if (isTurn[x] == true)
                {
                    turnPlayer = x + 1;
                }
            }

            return turnPlayer;
        }
    }
}