using UnityEngine;
using System.Collections;

public class ClsLanguage {





	public static string doBanCanMuaVip()
	{
		string vaothi = "\n\n(Để xem được lời giải thích đầy đủ bạn cần kích hoạt Vip)";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "\n\n(To get the full explanation you must be a member vip)";
		}

		return vaothi;
	}

	public static string doOf()
	{
		string vaothi = " của ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = " of ";
		}

		return vaothi;
	}


	public static string doDapSo()
	{
		string vaothi = "Đáp số: ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Result: ";
		}

		return vaothi;
	}


	public static string doLoading()
	{
		string vaothi = "Vui lòng đợi....\nHệ thống đang soạn đề thi";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Loading...Please Wait";
		}

		return vaothi;
	}


	public static string doFillNumber()
	{
		string vaothi = "Điền số thích hợp vào chỗ chấm (...) ?\n\n";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Fill in the missing number (...) ?\n\n";
		}

		return vaothi;
	}

	public static string doTongKet()
	{
		string vaothi = "Tổng kết";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Summary";
		}

		return vaothi;
	}

	public static string doVuotQua()
	{
		string vaothi = "Bạn ĐÃ vượt qua vòng ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "You have exceeded the level ";
		}

		return vaothi;
	}
	public static string doChuaVuotQua()
	{
		string vaothi = "Bạn CHƯA vượt qua vòng ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "You do not pass the level ";
		}

		return vaothi;
	}

	public static string doTongDiem()
	{
		string vaothi = "Tổng điểm 2 bài thi là: ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "The total score of 2 tests: ";
		}

		return vaothi;
	}

	public static string doContentMoney()
	{
		string vaothi = "Bài 2: Bạn điền kết quả đúng vào bảng của chú khỉ đang cầm trên tay sao cho phù hợp với câu hỏi ở trên bảng chính. Mỗi câu hỏi đúng được cộng 10 điểm làm sai trừ 5 điểm.";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Lesson 2: Enter the correct result on the board. Make 10 plus points. Failure minus 5 points. There are all 10 questions!";
		}

		return vaothi;
	}

	public static string doTileSapXep()
	{
		string vaothi = "Sắp xếp";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Sort Ascending";
		}

		return vaothi;
	}

	public static string doSapXep()
	{
		string vaothi = "Bài 1: Bạn hãy dùng ngón tay. Bạn chọn liên tiếp các ô có giá trị tăng dần để các ô lần lượt bị xóa khỏi bảng. Nếu bạn chọn sai quá 3 lần thì bài thi sẽ kết thúc.";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Lesson 1: Use your fingers. You select successive cells which have ascending values to removed them from the table. If you select wrongly more than 3 times, your test will end.";
		}

		return vaothi;
	}

	public static string doHoanThanhBaiThi()
	{
		string vaothi = "Bạn đã hoàn thành bài thi";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "You've completed the test";
		}

		return vaothi;
	}







	public static string doSoLienTruoc()
	{
		string vaothi = "Số liền trước ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Previous number ";
		}

		return vaothi;
	}

	public static string doSoLienSau()
	{
		string vaothi = "Số liền sau ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Next number ";
		}

		return vaothi;
	}
	public static string doHinhNguGiac()
	{
		string vaothi = "Hình ngũ giác";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Pentagon ";
		}

		return vaothi;
	}

	public static string doHinhLucGiac()
	{
		string vaothi = "Hình lục giác";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Hexagon ";
		}

		return vaothi;
	}

	public static string doHinhNgoiSao()
	{
		string vaothi = "Hình ngôi sao";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Star ";
		}

		return vaothi;
	}

	public static string doHinhChuNhat()
	{
		string vaothi = "Hình chữ nhật";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Rectangle ";
		}

		return vaothi;
	}


	public static string doHinhTron()
	{
		string vaothi = "Hình tròn";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Circle ";
		}

		return vaothi;
	}

	public static string doHinhTamGiac()
	{
		string vaothi = "Hình tam giác";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Triangular";
		}

		return vaothi;
	}

	public static string doHinhVuong()
	{
		string vaothi = "Hình vuông";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Square ";
		}

		return vaothi;
	}

	public static string doTitleCapBangNhau()
	{
		string vaothi = "Tìm cặp bằng nhau";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Find pairs of equal";
		}

		return vaothi;
	}

	public static string doLesson()
	{
		string vaothi = "Bài ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Lesson ";
		}

		return vaothi;
	}

	public static string doContentCapBangNhau()
	{
		string vaothi = " Bạn hãy dùng ngón tay. Bạn chọn liên tiếp 2 ô có giá trị bằng nhau hoặc đồng nhất với nhau. Khi chọn đúng, hai ô sẽ bị xóa khỏi bảng. Nếu chọn sai quá 3 lần bài thi sẽ kết thúc.";
		if (VioGameController.instance.tienganh)
		{
			vaothi = " Use your fingers. You select successive cells which have same values to removed them from the table. If you select wrongly more than 3 times, your test will end.";
		}

		return vaothi;
	}

	public static string doContentDinhNui()
	{
		string vaothi = " Bạn hãy dùng ngón tay. Bạn chọn 1 trong bốn đáp cho phù hợp vào ô trống cho phù hợp với kết quả. Nếu bạn chọn sai quá 3 lần thì bài thi sẽ kết thúc. Nếu chọn đúng được cộng 10 điểm còn chọn sai trừ 2 điểm";
		if (VioGameController.instance.tienganh)
		{
			vaothi = " Use your fingers. You choose one of four answers in the box for matching results. If you select the wrong more than 3 times, the test will end.";
		}

		return vaothi;
	}

	public static string doDiem()
	{
		string vaothi = "Điểm ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Coin  ";
		}

		return vaothi;
	}

	public static string doTime()
	{
		string vaothi = "Thời gian ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Time ";
		}

		return vaothi;
	}


	public static string doGiaiThich()
	{
		string vaothi = "Lời giải: ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Solve: ";
		}

		return vaothi;
	}

	public static string doVaoThi()
	{
		string vaothi = "Vào thi";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Play";
		}

		return vaothi;
	}
	public static string doContenQuangCao()
	{
		string vaothi = "Quảng cáo ứng dụng hữu ích sẽ được hiển thị cho bạn !";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Game advertising will be displayed !";
		}

		return vaothi;
	}
	public static string doQuangCao()
	{
		string vaothi = "Quảng cáo";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Advertise";
		}

		return vaothi;
	}

	public static string doXepHang()
	{
		string vaothi = "Xếp hạng";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Top 1000";
		}

		return vaothi;
	}

	public static string doMuaVip()
	{
		string vaothi = "Kích Hoạt Vip";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Buy Vip";
		}

		return vaothi;
	}
	public static string doContenVip()
	{
		string vaothi = "1.Bạn có thể nhận được câu trả lời đầy đủ cho các đáp án sai tại bài thi Đỉnh núi trí tuệ. \n\n 2.Bạn sẽ không bị làm phiền bởi quảng cáo. ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "1.You can get the complete answer for the wrong answer in test Intellectual peaks. \n\n 2.You will not be bothered by ads after the end of the game.";
		}

		return vaothi;
	}

	public static string doActiVip()
	{
		string vaothi = "Kích Hoạt Vip";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Member Vip";
		}

		return vaothi;
	}

	public static string doBatDau()
	{
		string vaothi = "Vòng thi thứ ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Level ";
		}

		return vaothi;
	}
	public static string doQuestion()
	{
		string vaothi = "Câu hỏi";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Question";
		}

		return vaothi;
	}

	public static string doContentBatDau()
	{
		string vaothi = "-Bạn cần phải vượt qua 3 bài tập. Điểm thi của bạn phải >=50% của vòng thi bạn mới qua.\n-Phụ huynh học sinh vui lòng không thi hộ học sinh, đó là hành động vi phạm luật.";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "You need to pass three exercises. Your score must be equal to or greater than 50 percent of the last round which you have just passed.";
		}

		return vaothi;
	}

	public static string doTitleDinhNui()
	{
		string vaothi = "Đỉnh núi trí tuệ";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Intellectual peaks";
		}

		return vaothi;
	}



	public static string doStart()
	{
		string vaothi = "Bắt đầu";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Play";
		}

		return vaothi;
	}

	public static string doContinute()
	{
		string vaothi = "Tiếp tục";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Continute";
		}

		return vaothi;
	}
	public static string doContentTuyetVoi()
	{
		string vaothi = "Thật là xuất sắc !  Bạn đã vượt qua được 20 vòng thi.";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Excellent ! You have crossed the 20 level";
		}

		return vaothi;
	}


	public static string doTitleTuyetVoi()
	{
		string vaothi = "Chúc mừng";
		if (VioGameController.instance.tienganh)
		{
			vaothi = "Excellent";
		}

		return vaothi;
	}


}
