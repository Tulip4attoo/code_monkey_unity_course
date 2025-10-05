Ok thì phần này, đầu tiên là gắn model player vào object cái đã (đương nhiên)
Sau đó là add thêm code rotate. Cái này có 1 số điểm chú ý:
+ tác giả bảo dùng hơn 10 năm mà chả hiểu Quaternion mấy nên không muốn dùng
+ có vài phương pháp để đổi rotation, tác giả nêu vài cách và chọn cách transform.forward vì vừa write vừa read được.
+ dùng Slerp để smooth

![[Pasted image 20251005094044.png]]

Có 1 điểm mình chưa hiểu lắm là vì sao khi ko Slerp thì góc reset về 0 (nên bấm xong thì nó quay mặt ra 1 góc cố định), còn Slerp thì ko gặp vấn đề này, nó giữ góc của player.

Trả lời:
+ `transform.forward` là 1 vector được normalized, nên là khi moveDir = 0 thì nó trả về kết quả mặc định, face north.
+ Slerp của `transform.forward` và 0 là 1 vector cùng hướng với `transform.forward`, nên dĩ nhiên là giữ hướng.
+ Do normalized nên không có chuyện hội tụ về 0.
That's nice. Có thể chỉnh xíu như này, hoặc ko cần thiết.

![[Pasted image 20251005095425.png]]