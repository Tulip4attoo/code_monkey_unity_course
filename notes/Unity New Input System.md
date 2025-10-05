Thật ra cũng không new lắm, có vài năm và hệ thống cũ bị auto turn off rồi, gọi là curent thì chính xác hơn.

Thì như ta đã nói, ta vốn chọn both nên cũng không cần chỉnh gì. Có lẽ both thì có thể có vấn đề hơn new (mà chả quan trọng, ko cần suy xét gì cho phiền).

Ok, thì ta sẽ tạo 1 cái `Input Action` để dùng. Sau đó bấm vào, có option Generate C# code để tạo các control, code này Unity tạo nên ta cũng không cần để ý gì.
![[Pasted image 20251005115504.png]]

Phía handle input thì ta tách ra khỏi Player cho gọn. File mới thì đơn giản thế này thôi.
![[Pasted image 20251005115657.png]]Bên `Player.cs` thì nó như này:
![[Pasted image 20251005115750.png]]Ở đây thì ta chú ý, là GameInput sẽ xử lý thêm phần từ Input get được, trả về Movement vector (hmmm, nghe cũng hơi sao sao, tức là game input không chỉ để xác định game input, mà còn để xử lý 1 số vấn đề liên quan ở game input, về sau thì sao, vd action? Thôi tính sau).

Tất nhiên là ta cần setting các phím. Có thể dễ dàng làm nhiều bộ phím, rồi cho gamepad các kiểu.

![[Pasted image 20251005120632.png]]

Dive vào code 1 chút, thì khi đọc, mình có 1 câu hỏi:
+ tại sao lại là `    private PlayerInputActions playerInputActions;`, và thế mà nó cũng hiểu, ko cần gán-trỏ như `SerializeField`. Thì lý do là vì ở bước tạo C# script phía trên, ta đã tạo 1 class mới rồi, có code, và do đó ta có thể get ở các file khác thôi.
+ ta tạo mới và enable để nghe input, chứ ko phải trỏ về cái gì nên code thế này là rõ ràng, trực tiếp và tường minh.
	+ Analogy dễ hiểu:
```csharp
// Giống như:
List<int> numbers = new List<int>();  // ✅ Tạo mới

// Còn SerializeField như:
[SerializeField] Transform target;    // 👉 Trỏ đến Transform đã có
```

![[Pasted image 20251005115657.png]]