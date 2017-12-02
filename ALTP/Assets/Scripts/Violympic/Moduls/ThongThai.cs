using UnityEngine;
using System.Collections;

public class ThongThai  {



	string question;
	int level;
	int ketqua;
	string giaithich;



	public ThongThai(string question,int ketqua,string giaithich,int level)
	{
		this.question = question;
		this.ketqua = ketqua;
		this.level = level;
		this.giaithich = giaithich;
	}

	public string Giaithich {
		get {
			return giaithich;
		}
	}

	public string Question {
		get {
			return question;
		}
	}

	public int Level {
		get {
			return level;
		}
	}



	public int Ketqua {
		get {
			return ketqua;
		}
	}


}
