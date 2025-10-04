Tác giả có nói rằng bt sẽ chỉ add post processing much later on (rõ ràng, như nghi vấn của mình). Tuy vậy, ở đây là 1 cái course nên làm post processing nhìn cho sướng mắt.

Đã chọn URP nên thật ra cũng đơn giản.

Ok, thì ở đây sẽ làm 2 cái:
+ 1 là setup scene đơn giản để biết post process thì trông nó sẽ như nào
+ 2 là override mấy cái setting bên Global Volume để trông cho đẹp.

![[Pasted image 20251004164149.png]]
Tác giả nhắc 1 chút về việc có 1 số post process hiển thị ko chuẩn/ko hiện/ko tốt ở Scene view, mà bên Game view mới ngon. Có thể đã fix ở Unity 6, cơ mà vẫn nên chọn Game view hơn (mà lười vl thôi ksao đâu lol)

Khác version nên thật ra cũng hơi khác nhau xíu, mà chắc cũng như nhau ấy mà.

Btw, bên volume thì tác giả xóa hết, override lại những thứ này:
![[Pasted image 20251004170606.png]]
có 1 cái thấy ảnh hưởng tương đối bên renderer là
![[Pasted image 20251004170645.png]]

Chỉnh lại FOV thành 20 nữa. Kết quả thì trông như này, khá ổn đó chứ.
![[Pasted image 20251004170714.png]]
Nếu tắt hết đi thì sẽ như này, trông hơi chán hơn thật
![[Pasted image 20251004170810.png]]

Ok, sau đó ta xóa các vật thể đi và move to phần tiếp theo.