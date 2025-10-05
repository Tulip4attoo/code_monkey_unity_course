Trước hết ta tạo 1 Player object.
Ta tạo Mesh riêng cho Object. Cái này thì cũng là 1 best practice thôi. Mà kể ra như player hơi phức tpaj tý thì là 1 đống object ghép vào chứ còn ko chỉ 1 model không (vd như đeo kính/bỏ kính).

Ok, ban đầu ta dùng old input system, rồi sau sẽ refactor lại. Mình dùng Unity 6.2 nên là cũng cần điều chỉnh ở setting 1 chút để nó chạy bt.

Code thì cũng tương đối thường gặp như này
![[Pasted image 20251005090956.png]]

Cái đoạn deltaTime thì rõ rồi.
Tác giả có đưa lý do vì sao dùng vector2 thay cho vector3 bởi vì nó sẽ tiện dùng cho các trường hợp dùng gamepad hơn. So-so, nếu như mình sẽ dùng Vector3 luôn. Còn lại thì chắc sau sẽ bỏ ra ngoài Update.

Với cả dùng `SerializeField` để vẫn là private nhưng chỉnh được ở Edtior. Nice.

Nói chung cũng không có gì.