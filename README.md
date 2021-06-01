## Các nhánh của dự án
- Base: toàn bộ các config đầu của dự án
- main: nhánh chính của dự án.
- maintain: nhánh chỉnh sửa dự án khi gặp lỗi
- add_readme: update_readme
- release: chứa toàn bộ thư mục của dự án.
 
Do đặc thù của engine Unity nên toàn bộ các tài nguyên cần quản lý chỉ nằm trong thư mục Assets, do vậy nhánh chính main và nhánh phụ maintain quản lý riêng cho thư mục này.
Do vậy, khi muốn tải dự án về chạy từ đầu thì cần pull từ nhánh release về vì chứa cả thư mục Assets và các thư mục khác.
 
## Cách cài đặt
- Cài đặt Unity2019 và UnityHub.
- Pull từ nhánh release ,mở ra bằng Unity2019.
- Chọn scene( trong thư mục Assets/Scene) bắt đầu là MainScene.
- Nhấn Play trong Unity để bắt đầu chơi.
 

## Gold Miner thế hệ mới
 
Tựa game Gold Miner chắc hẳn không còn quá xa lạ với chúng ta, nó như một phần tạo nên tuổi thơ của chúng ta
@ -18,16 +35,10 @@ Unity, C#: platform hộ trợ tối đa cho việc lập trình game
- Tính năng về suy tầm đá quý: Bạn có một khung đá quý gồm 5 viên đá quý với từng màu sắc, hình dáng riêng biệt, nhiệm vụ của bạn là sưu tầm tất cả những viên đá quý đấy, sau khi thu thập xong bạn sẽ có một phần thưởng đặc biệt
- Thêm mới các loại đối tượng có thể móc được: đầu lâu, đá kim cương, ...
 
## Các nhánh của dự án
 
- Base: toàn bộ các config đầu của dự án
- main: nhánh chính của dự án
- maintain: nhánh chỉnh sửa dự án khi gặp lỗi
- add_readme: update_readme
 
## Thành Viên
- Nguyễn Đức Anh (trưởng nhóm)
- Lương Tiến Mạnh
- Nguyễn Huy Khôi
- Hoa Xuân Dương
- Phạm Hữu Anh Quốc