Đoạn này phải nói thật là mới với mình, liên quan tới cơ chế pub/sub, mà mình hoàn toàn chưa biết.

Ok thì ta phân tích code:
+ đầu tiên thì ta thêm phím Interact.
+ phần GameInput sẽ handle cơ chế pub sub, bằng việc add thêm subscribe vào như thế này
![[Pasted image 20251005165558.png]]
Cụ thể hơn, đây là **two-level publish-subscribe (pub-sub) pattern**:
+ Level 1: Unity Input System → GameInput (Subscriber)
	+ `playerInputActions.Player.Interact.performed += Interact_Performed;`
	+ **Publisher**: Unity's Input System (`playerInputActions.Player.Interact`)
	+ **Subscriber**: `GameInput` class (via the `Interact_Performed` method)
	+ **Event**: `performed` (triggered when the Interact action is performed)
	+ ở đây, khi user bấm phím (perform event), thì Unity's Input System (`playerInputActions.Player.Interact`) publish cái event này, và GameInput class (cả class nói chung) sẽ nhận noti qua `Interact_Performed` (tức là )
	+ 
		```
		[Player nhấn phím E]
		        ↓
		[Unity Input System phát hiện]
		        ↓
		[Input System: "Có event 'performed' xảy ra!"]
		        ↓
		[Input System TỰ ĐỘNG GỌI hàm Interact_Performed của GameInput]
		        ↓
		[GameInput nhận được thông báo và xử lý trong Interact_Performed]
		```

Tiếp đến là cơ chế pub sub ở Player để handle
![[Pasted image 20251005171146.png]]
Phần code `GameInput_OnInteractAction` thì gần như là như cũ thôi. Nhưng có 1 số cái đặc biệt:
+ `gameInput.OnInteractAction += GameInput_OnInteractAction;` để khai báo pub sub
+ chúng ta so sánh `private void GameInput_OnInteractAction(object sender, System.EventArgs e)` và `private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext context)` có input khác hẳn nhau. Vì sao? Vì 1 cái là nó theo 2 chuẩn khác nhau, 1 là Unity Input System (chuẩn riêng của Unity), 1 là C# Event Standard (chuẩn .NET). Thật ra vẫn có thể làm cùng chuẩn được nếu dùng UnityEvent (nó sẽ thay đổi tương đối code phần pub sub, dễ đọc hơn mà có vẻ chưa toàn diện được như code C#).

Thì vấn đề lớn nhất ở đây, chính là do syntax hơi lạ nên cognition load cao. Thực ra cơ chế rất đơn giản:

- nếu 1 sub được add vào pub thì khi có event ở pub, sub sẽ biết.
- ở đây, GameInput.Interact_Performed là sub, do đó sẽ hoạt động nếu như pub có event.
- ta làm 1 cái nữa, với OnInteractAction là pub, và GameInput_OnInteractAction() là sub
- thì pub input nhận event -> gọi sub OnInteractAction, OnInteractAction gọi GameInput_OnInteractAction()

Mình nghĩ là qua 1 thời gian thì sẽ load được cái cơ chế này thôi, nếu mà gặp 1 vài lần nữa.