# Báo cáo tuần 2
## Tên nhóm: Nhóm SE (21010630@st.phenikaa-uni.edu.vn)
## Thành viên nhóm:
1. Phạm Hồng Phúc - Nhóm trưởng *****
2. Phạm Sỹ Nhật Nhân *****
3. Nguyễn Trường Nghĩa *****
4. Vũ Nhật Minh *****
5. Đỗ Xuân Thành *****
6. Phạm Anh Vũ *****

# Yêu cầu bài toán

### Xây dựng Phần mềm quản lý sản xuất nhằm mục đích chuẩn hóa lại quy trình, nâng cao hiệu quả hoạt động sản xuất, tối đa hóa năng suất của máy móc từ đó tối ưu được nguồn lực của đơn vị, đạt được các tiêu chí như sau:
- Chuẩn hóa danh mục dữ liệu cho các đối tượng: khách hàng, nhà cung cấp, nguyên vật liệu, công cụ dụng cụ, sản phẩm.
- Tổng hợp thông tin và theo dõi tiến độ cụ thể của từng đơn đặt hàng.
- Tự động lập kế hoạch sản xuất dựa trên các yêu cầu đặt hàng và định mức quy định tại đơn vị, so sánh thực tế sản xuất với kế hoạch đề ra.
- Quản lý hiệu quả khâu nhập xuất kho: nguyên vật liệu, thành phẩm.
- Quản lý quy trình sản xuất: tạo lệnh sản xuất trực tiếp trên phần mềm, theo dõi, thống kê lại các thông tin trong quá trình sản xuất theo thời gian thực, đồng thời phục vụ cho việc kiểm tra và giám sát sự cố trong quá trình phát sinh.

# Xác định yêu cầu chức năng phần mềm
### 1. Quản lý sản xuất
#### Phần mềm cho phép việc tập hợp các yêu cầu về khách hàng, nhà cung cấp, nguyên vật liệu, công cụ dụng cụ, sản phẩm tại các thời điểm nhất định.
### 2. Quản lý kế hoạch sản xuất
#### Giúp thực hiện tạo các lệnh sản xuất dựa trên số liệu hàng hóa cần sản xuất.   
- Phân hệ hỗ trợ ghi nhận thông tin và quản lý kế hoạch sản xuất:
- Phân cấp theo kế hoạch tổng hợp và kế hoạch chi tiết.
- Liên kết các kế hoạch sản xuất.
- Phân loại kế hoạch theo: loại kế hoạch, tình trạng kế hoạch, đối tác, thời kỳ, loại sản phẩm
- Thông tin về thời gian thực hiện công đoạn.
- Tỷ lệ hao hụt, phế phẩm.
- Thông tin quá trình chuyển giao sản phẩm giữa hai công đoạn với nhau.
- Thông tin về định mức nguyên vật liệu, định mức lao động, định mức sử dụng máy móc, thiết bị.
- Tùy biến thay đổi thiết kế sản phẩm trong quá trình sản xuất.
### 3. Quản lý nguyên vật liệu
- Hỗ trợ việc tính toán các yêu cầu về nguyên vật liệu dựa theo kế hoạch sản xuất.
- Tự động tính toán nhu cầu nguyên vật liệu để đưa ra các đề xuất mua nguyên vật liệu phục vụ sản xuất.
- Hỗ trợ việc sản xuất của nhà máy với việc tính toán khả năng cung ứng của nguyên vật liệu và các nguồn lực khác.
### 4. Quản lý tiến độ sản xuất
- Theo dõi tiến độ sản xuất từng đơn hàng và quá trình sản xuất.
- Theo dõi tiến độ sản xuất từng công đoạn.
### 5. Quản lý nhân công
- Lên lịch làm việc, đi ca cho nhân viên.
- Theo dõi quá trình vào – ra.
- Theo dõi, điều chuyển nhân công từ phân xưởng này sang phân xưởng khác
- Phân công công việc, phân công sản phẩm cho nhân viên theo nhóm hoặc chi tiết đến từng người
### 6. Quản lý sản phẩm
- Quản lý danh sách sản phẩm
- Quản lý thông tin sản phẩm
- Quản lý hình ảnh sản phẩm
- Quản lý lịch sử thay đổi giá sản phẩm
### 7. Quản lý kho
- Quản lý xuất, nhập
- Hỗ trợ quản lý kho bằng mã hàng hay bằng mã vạch (barcode)
- Hỗ trợ quản lý các mặt hàng cần theo dõi đích danh: serial number, IMEX, ...
- Hỗ trợ cảnh báo hàng tồn kho theo định mức
- Hỗ trợ kiểm kho tự động bằng máy kiểm kho
- Quản lý các phiếu nhập, xuất, điều chỉnh, kiểm kê kho
- Theo dõi chính xác việc nhập xuất của từng sản phẩm hay nhóm sản phẩm
- Xem tồn kho hiện tại của sản phẩm một cách nhanh chóng
- Dự đoán số lượng hàng sẽ xuất theo dữ liệu xuất trong lịch sử
### 8. Quản lý khách hàng
- Ghi nhận thông tin khách hàng (Tên, Địa chỉ, Mã số thuế,…) và phân nhóm khách hàng. Cho phép phân loại và đánh giá khách hàng theo nhiều tiêu chí khác nhau (mức độ tiềm năng, khu vực địa lý, ngành nghề kinh doanh,…). Dễ dàng bổ sung thêm các trường thông tin vào tiêu chí quản lý, chăm sóc và đánh giá khách hàng tiềm năng
- Ghi nhận Lịch sử giao tiếp với khách hàng (Điện thoại, Gặp mặt, Email,…)
- Lên kế hoạch làm việc với khách hàng và kiểm soát tiến độ hoàn thành
### 9. Chức năng báo cáo, phân tích, hệ thống động
- Phân tích chi phí nhân công, nguyên vật liệu, máy móc sử dụng cho từng lô sản phẩm, từng đơn hàng
- So sánh Chi phí sản xuất tại mỗi công đoạn trong quy trình và chi phí toàn quy trình bao gồm: chi phí nguyên vật liệu, chi phí nhân công, chi phí máy móc thiết bị, chi phí chuyển công đoạn chi phí sử dụng giữa các lô sản xuất...
# Xác định yêu cầu phi chức năng
- An ninh: Hệ thống phải được bảo mật khỏi sự truy cập trái phép.
- Hiệu suất: Hệ thống phải có khả năng xử lý số lượng người dùng cần thiết mà không có bất kỳ sự suy giảm nào về hiệu suất.
- Khả năng mở rộng: Hệ thống phải có thể tăng hoặc giảm quy mô khi cần thiết.
- Khả dụng: Hệ thống phải sẵn sàng khi cần thiết.
- Bảo trì: Hệ thống phải dễ bảo trì và cập nhật.
- Tính di động: Hệ thống phải có thể chạy trên các nền tảng khác nhau với những thay đổi tối thiểu.
- Độ bền: Hệ thống phải đáng tin cậy và đáp ứng các yêu cầu của người sử dụng.
- Khả năng sử dụng: Hệ thống phải dễ sử dụng và dễ hiểu.
- Khả năng tương thích: Hệ thống phải tương thích với các hệ thống khác.
- Tuân thủ: Hệ thống phải tuân thủ tất cả các luật và quy định hiện hành.
