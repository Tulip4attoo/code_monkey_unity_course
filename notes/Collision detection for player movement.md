Phần này chính ra hơi lằng nhằng.

Flow tác giả đưa ra thật ra hơi lạ với mình: thay vì tạo 1 cái collider ngay ở object thì làm 1 cái Cast để check. Mỗi option có vài đặc điểm riêng:
+ cách **Rigidbody + Collider** thì thiên về physic, dễ hook, nhưng có thể jitter và có thể gặp nhiều glitch hơn
+ cách kia thì cực hơn nhưng tiện, thích define kiểu gì thì làm kiểu đó. Dễ cho nhiều logic custom.

Hoàn toàn có thể hybrid thoải mái.

Code thì không khó mà hơi lằng nhằng xíu
![[Pasted image 20251005142049.png]]
Chú ý thì:
+ ở đây làm hơi thủ công, nhất là đoạn rdius với height. Cái này mình thấy làm 1 cái capsule hay hơn hẳn, dễ fit và debug hơn nữa.
+ có thể viết code ngắn hơn, code tác giả cũng hơi khác code mình xíu, nhưng flow giữ nguyên nên cũng chả có gì khác biệt
+ đoạn hug wall có thể điều chỉnh tốc độ hoặc không, nói chung tùy design.

Logic thì đơn giản và cũng trực tiếp, nhưng hơi lạ nên code cũng hơi lâu xíu xíu.