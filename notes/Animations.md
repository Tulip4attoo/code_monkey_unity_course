Anim thật ra là 1 phần khá phức tạp mà vấn đề là bản thân mình cũng không có mấy hiểu biết về nó, đợt xưa làm anim cho Echo rất là xoắn quẩy xoắn quẩy.

Ok, thì tác giả có hướng dẫn làm, record anim đơn giản. Nhưng mà thấy vẫn rất căng vì nó là 1 bộ kỹ năng hoàn toàn khác, và khả năng là mình cũng không làm đâu ấy (nhưng có thể Dawn thì okie, mà anim của Dawn có khi code/shader thôi chứ chả phải anim)

Làm anim Idle thì bt chứ làm anim Walk phiền vd :))) chỉnh mãi mới thấy tàm tạm okie.

Ok, coi như bỏ qua phần tạo anim thì ta chú ý 1 số phần sau:
+ ta tạo param và set các condition như phần phía dưới
![[Pasted image 20251005105425.png]]
+ code thì ta có trỏ vào sao cho hợp lý là được. Vd như ở đây ta viết như này
	+ đầu tiên, ta cần 1 method để get được player đang đi hay đứng yên. Ta tạo method ở trong `Player.cs`
	+ bên `PlayerAnimator.cs` thì ta cũng đơn giản là get nó thôi. Mà cái này mình nghĩ lấy parent có khi còn hay hơn? (thật ra thì ko hay lắm, nhưng nên viết dạng hybrid thì là tốt nhất, fallback khi quên gán hay có vấn đề chẳng hạn).
![[Pasted image 20251005105521.png]]
![[Pasted image 20251005105947.png]]

btw thì như đã nói, sau khi dyaj 1 số cơ bản thì tác giả bảo là revert lại, dùng cái tạo sẵn đi thì tốt hơn. Về cơ bản anim cũng nên tách biệt, chứ người code làm anim thì hơi phiền.