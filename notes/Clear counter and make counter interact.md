Phần này khá dài và có nhiều chủ đề con:
+ tạo prefab và điều chỉnh. Cách dễ track là click vào Open
		![[Pasted image 20251005151757.png]]
		khi đó màn hình sẽ như này, rất dễ nhận biết
		![[Pasted image 20251005151843.png]]
		và muốn lưu thì làm xong ta click chữ Scene góc top left để back về scene là có thể lưu vào prefab.
+ ta dùng Raycast để detect vật. Ở đây có 1 số lưu ý nhỏ:
![[Pasted image 20251005152023.png]]
		+ Raycast thì có cái phần out như là OpenCV bên python, nó cho output từ hàm luôn (chứ ko nằm ở return, that's fine).
		+ ta không dùng Tag vì hệ thống Tag là string, không tốt lắm. Ta check component xem có phải type cần tìm không (hình như bên UE cũng là theo cơ chế này). CŨng okie thôi, đỡ phải tạo và quản lý tag, hơi lằng nhằng mà dễ nhầm.
		+ `counterLayerMask` để chỉ tương tác với các layer tương ứng. Nghĩa là vd có 1 cái tường thì ta vẫn tương tác được (kể cả tường ko invi). Cái này chỉnh thì chắc cũng ko khó, thêm tag invi hay gì đó chẳng hạn, whatever, nhưng mình nghĩ là không khó.
		+ bên Counter thì làm 1 class đơn giản là xong rồi
		 ![[Pasted image 20251005152529.png]]

Nói chung là cũng nhiều thứ nhưng logic cũng đơn giản thôi: raycast để check, dụng phải vật gì theo layer định trước thì ta get object đó, rồi thì chạy các function của object đó nếu muốn.