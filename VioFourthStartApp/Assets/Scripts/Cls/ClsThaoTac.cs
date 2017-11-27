using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ClsThaoTac  {

    public static double doKetQua(string tmp)
    {
        double ok;
        if (GameController.instance.level == 14 || GameController.instance.level == 15 || GameController.instance.level == 19 || GameController.instance.level == 20)
        {
            if (tmp.Contains(":"))
            {
                string[] mang = tmp.Split(':');
                ok = Math.Round((double.Parse(mang[0]) / double.Parse(mang[1])), 6);
            }
            else
            {
                ok = double.Parse(tmp);
            }
        }
        else
        {
            ok = double.Parse(tmp);
        }
        return ok;
    }

    public static string CoverTimeToString(int mTime)
    {
        string stTime = "";
        int timeN = mTime / 60;
        int timeD = mTime % 60;
        if (timeD >= 10)
        {
            stTime = "" + timeN + ":" + timeD;
        }
        else
        {
            stTime = "" + timeN + ":0" + timeD;
        }
        return stTime;
    }

   

    public static List<PhepToan> FakeData(int dau, int cuoi,int sl)
    {
       
        List<PhepToan> lstTam = new List<PhepToan>();
        while (lstTam.Count < sl)
        {
            int chon = UnityEngine.Random.Range(dau, cuoi) + 1;
            if (lstTam.Exists(e => e.Ketqua.Equals("" + chon)))
            {
                continue;
            }
            else
            {
                
                PhepToan pt = new PhepToan("" + chon, "" + chon, "number");
                lstTam.Add(pt);
            }
            
        }
  
    
        return lstTam;
        
    }

  
   


    public static PhepToan getPhepToan(PhepToan giatri,ref List<PhepToan> lst, int pc)
    {
        lst.RemoveAt(pc);
        List<PhepToan> tmg = new List<PhepToan>();
        foreach (PhepToan item in lst)
        {
            if (item.Congthuc.Equals(giatri.Congthuc))
                continue;
            if (item.Ketqua == giatri.Ketqua)
            {
                tmg.Add(item);
            }
        }

        if (tmg.Count > 0)
        {
            int chon = UnityEngine.Random.Range(0, tmg.Count);
            string tam = "" + tmg[chon].Congthuc;
            if (tam.Contains("/"))
            {
                return new PhepToan(tmg[chon].Congthuc, tmg[chon].Ketqua, "phanso");
            }
            else
            {
                return new PhepToan(tmg[chon].Congthuc, tmg[chon].Ketqua, "number");
            }
           
        }
        else
        {
            return new PhepToan("" + giatri.Ketqua, giatri.Ketqua, "number");
        }
    }

    }

