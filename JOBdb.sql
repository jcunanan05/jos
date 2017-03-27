-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 27, 2017 at 08:15 AM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 7.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jobdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `category_tb`
--

CREATE TABLE `category_tb` (
  `category_AI` int(11) NOT NULL,
  `category_id` varchar(20) AS (concat('cat_',category_AI)) VIRTUAL,
  `category_name` varchar(50) NOT NULL,
  `added_by_emp_id` varchar(45) NOT NULL DEFAULT 'Default'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `category_tb`
--

INSERT INTO `category_tb` (`category_AI`, `category_id`, `category_name`, `added_by_emp_id`) VALUES
(1, 'cat_1', 'Guess', 'Default'),
(2, 'cat_2', 'Tissot', 'Default'),
(3, 'cat_3', 'Casio', 'Default');

-- --------------------------------------------------------

--
-- Table structure for table `customer_tb`
--

CREATE TABLE `customer_tb` (
  `customer_AI` int(11) NOT NULL,
  `customer_id` varchar(30) AS (concat('cust_',customer_AI)) VIRTUAL,
  `customer_name` varchar(100) NOT NULL,
  `customer_contact` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `customer_tb`
--

INSERT INTO `customer_tb` (`customer_AI`, `customer_id`, `customer_name`, `customer_contact`) VALUES
(1, 'cust_1', 'Cunanan, Jonathan Albert M.', '09123456789'),
(2, 'cust_2', 'Cunanan, Juan Paulo M.', '09351221329'),
(7, 'cust_7', 'Fernando, Mateo G.', '09123218172'),
(8, 'cust_8', 'Cunanan, Adonis P.', '09178294910');

-- --------------------------------------------------------

--
-- Table structure for table `employee_tb`
--

CREATE TABLE `employee_tb` (
  `emp_AI` int(11) NOT NULL,
  `emp_id` varchar(20) AS (CONCAT('emp_',emp_AI)) VIRTUAL,
  `full_name` varchar(100) NOT NULL,
  `username` varchar(32) NOT NULL,
  `position_type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee_tb`
--

INSERT INTO `employee_tb` (`emp_AI`, `emp_id`, `full_name`, `username`, `position_type`) VALUES
(1, 'emp_1', 'Jonathan Albert M. Cunanan', '50cj', 1),
(2, 'emp_2', 'Manny M. Manegerial', 'manager01', 2),
(3, 'emp_3', 'Tessie Ting', 'testuser', 1),
(4, 'emp_4', 'Juan Paulo M. Cunanan', 'juanpaulo', 1);

-- --------------------------------------------------------

--
-- Table structure for table `inventory_tb`
--

CREATE TABLE `inventory_tb` (
  `item_AI` int(11) NOT NULL,
  `item_id` varchar(20) AS (concat('item_',item_AI)) VIRTUAL,
  `item_model` varchar(100) NOT NULL,
  `item_quantity` int(11) NOT NULL DEFAULT '0',
  `item_price` decimal(13,2) NOT NULL,
  `critical_amount` int(11) NOT NULL DEFAULT '0',
  `added_by_emp_id` varchar(20) NOT NULL DEFAULT 'Default',
  `supplier_id` varchar(20) NOT NULL,
  `category_id` varchar(20) NOT NULL,
  `part_id` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `inventory_tb`
--

INSERT INTO `inventory_tb` (`item_AI`, `item_id`, `item_model`, `item_quantity`, `item_price`, `critical_amount`, `added_by_emp_id`, `supplier_id`, `category_id`, `part_id`) VALUES
(1, 'item_1', 'AA3201', 12, '20.00', 3, 'Default', 'supp_3', 'cat_1', 'part_1'),
(2, 'item_2', 'AB1230', 5, '12.00', 3, 'Default', 'supp_1', 'cat_1', 'part_2'),
(3, 'item_3', 'M01B35', 8, '5.50', 2, 'Default', 'supp_5', 'cat_1', 'part_2'),
(4, 'item_4', '12MN013', 5, '3.00', 2, 'Default', 'supp_4', 'cat_1', 'part_1'),
(5, 'item_5', 'A0124AB', 18, '12.00', 6, 'Default', 'supp_3', 'cat_3', 'part_1');

-- --------------------------------------------------------

--
-- Table structure for table `job_desc_tb`
--

CREATE TABLE `job_desc_tb` (
  `job_desc_AI` int(11) NOT NULL,
  `job_desc_id` varchar(50) AS (concat('job_desc_',job_desc_AI)) VIRTUAL,
  `job_desc` varchar(300) NOT NULL,
  `job_desc_price` decimal(13,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `job_desc_tb`
--

INSERT INTO `job_desc_tb` (`job_desc_AI`, `job_desc_id`, `job_desc`, `job_desc_price`) VALUES
(1, 'job_desc_1', 'Battery Replacement', '100.00'),
(2, 'job_desc_2', 'Watch Hand Replacement', '110.00');

-- --------------------------------------------------------

--
-- Table structure for table `job_type_tb`
--

CREATE TABLE `job_type_tb` (
  `job_type` int(11) NOT NULL,
  `job_type_remark` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `job_type_tb`
--

INSERT INTO `job_type_tb` (`job_type`, `job_type_remark`) VALUES
(1, 'Admit'),
(2, 'On-the-go');

-- --------------------------------------------------------

--
-- Table structure for table `login_tb`
--

CREATE TABLE `login_tb` (
  `username` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL,
  `user_type` int(11) NOT NULL DEFAULT '1',
  `acct_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `login_tb`
--

INSERT INTO `login_tb` (`username`, `password`, `user_type`, `acct_id`) VALUES
('50cj', '8fe4c11451281c094a6578e6ddbf5eed', 1, 1),
('manager01', '8fe4c11451281c094a6578e6ddbf5eed', 1, 2),
('testuser', '8fe4c11451281c094a6578e6ddbf5eed', 1, 3),
('juanpaulo', '8fe4c11451281c094a6578e6ddbf5eed', 1, 4);

-- --------------------------------------------------------

--
-- Table structure for table `part_tb`
--

CREATE TABLE `part_tb` (
  `part_AI` int(11) NOT NULL,
  `part_id` varchar(20) AS (concat('part_',part_AI)) VIRTUAL,
  `part_name` varchar(50) NOT NULL,
  `added_by_emp_id` varchar(20) NOT NULL DEFAULT 'Default'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `part_tb`
--

INSERT INTO `part_tb` (`part_AI`, `part_id`, `part_name`, `added_by_emp_id`) VALUES
(1, 'part_1', 'Watch Left Hand', 'Default'),
(2, 'part_2', 'Watch Right Hand', 'Default');

-- --------------------------------------------------------

--
-- Table structure for table `position_type_tb`
--

CREATE TABLE `position_type_tb` (
  `position_type` int(11) NOT NULL,
  `position_type_remark` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `position_type_tb`
--

INSERT INTO `position_type_tb` (`position_type`, `position_type_remark`) VALUES
(1, 'Technician'),
(2, 'Manager'),
(3, 'Cashier');

-- --------------------------------------------------------

--
-- Table structure for table `repair_job_tb`
--

CREATE TABLE `repair_job_tb` (
  `job_AI` int(11) NOT NULL,
  `job_id` varchar(50) AS (concat('job_',job_AI)) VIRTUAL,
  `date_time_added` datetime NOT NULL,
  `customer_id` varchar(30) NOT NULL,
  `job_item_name` varchar(100) NOT NULL,
  `job_type` int(11) NOT NULL,
  `total_price` decimal(13,2) NOT NULL,
  `warranty_type` varchar(30) NOT NULL DEFAULT 'warr_0',
  `watch_serial_no` varchar(100) DEFAULT NULL,
  `watch_kind` int(11) NOT NULL,
  `watch_build` int(11) NOT NULL,
  `watch_remark` varchar(500) NOT NULL,
  `technician_id` varchar(20) DEFAULT NULL,
  `repair_status_id` int(11) DEFAULT '1',
  `start_repair_date` date NOT NULL,
  `expected_claim_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `repair_job_tb`
--

INSERT INTO `repair_job_tb` (`job_AI`, `job_id`, `date_time_added`, `customer_id`, `job_item_name`, `job_type`, `total_price`, `warranty_type`, `watch_serial_no`, `watch_kind`, `watch_build`, `watch_remark`, `technician_id`, `repair_status_id`, `start_repair_date`, `expected_claim_date`) VALUES
(8, 'job_8', '2017-03-24 23:11:04', 'cust_8', 'Guess watch', 1, '242.00', 'warr_1', '1l294jaie03', 1, 1, 'brown bracelet', 'emp_4', 1, '2017-03-24', '2017-03-24'),
(9, 'job_9', '2017-03-24 23:15:31', 'cust_1', 'casio watch', 1, '124.00', 'warr_1', '024jav924sla', 2, 2, 'gold bracelet', 'emp_3', 1, '2017-03-24', '2017-03-24'),
(10, 'job_10', '2017-03-24 23:23:47', 'cust_2', 'Casio watch', 1, '122.00', 'warr_2', '123lasj1234la', 2, 1, 'lady watch gold', 'emp_1', 1, '2017-03-24', '2017-03-24'),
(11, 'job_11', '2017-03-24 23:25:20', 'cust_1', 'Gus watch', 1, '124.00', 'warr_1', '-0k234d92r', 1, 2, 'men watch silver', 'emp_3', 1, '2017-03-24', '2017-03-24'),
(12, 'job_12', '2017-03-24 23:33:04', 'cust_8', 'gshock watch', 1, '124.00', 'warr_1', '1lkjdf10dfj', 2, 1, 'lady watch', 'emp_4', 1, '2017-03-24', '2017-03-24'),
(14, 'job_14', '2017-03-26 23:18:54', 'cust_7', 'LuckyXiao Watch', 2, '120.00', 'warr_1', '091k4jdkal2', 2, 2, 'gold plated', 'emp_3', 1, '2017-03-26', '2017-03-29');

-- --------------------------------------------------------

--
-- Table structure for table `repair_part_tb`
--

CREATE TABLE `repair_part_tb` (
  `job_id` varchar(50) NOT NULL,
  `item_id` varchar(20) NOT NULL,
  `item_quantity` int(11) NOT NULL,
  `price_each` decimal(13,2) NOT NULL,
  `items_price` decimal(13,2) NOT NULL,
  `quantity_exist` tinyint(1) NOT NULL DEFAULT '1',
  `ai_column` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `repair_part_tb`
--

INSERT INTO `repair_part_tb` (`job_id`, `item_id`, `item_quantity`, `price_each`, `items_price`, `quantity_exist`, `ai_column`) VALUES
('job_8', 'item_1', 1, '20.00', '20.00', 1, 2),
('job_8', 'item_2', 1, '12.00', '12.00', 1, 3),
('job_10', 'item_5', 1, '12.00', '12.00', 1, 6),
('job_11', 'item_5', 2, '12.00', '24.00', 1, 7),
('job_12', 'item_5', 2, '12.00', '24.00', 1, 8),
('job_14', 'item_1', 1, '20.00', '20.00', 1, 10);

-- --------------------------------------------------------

--
-- Table structure for table `repair_status_tb`
--

CREATE TABLE `repair_status_tb` (
  `repair_status_id` int(11) NOT NULL,
  `repair_status_remark` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `repair_svc_tb`
--

CREATE TABLE `repair_svc_tb` (
  `job_id` varchar(50) NOT NULL,
  `job_desc_id` varchar(50) NOT NULL,
  `job_desc_price` decimal(13,2) NOT NULL,
  `ai_column` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `repair_svc_tb`
--

INSERT INTO `repair_svc_tb` (`job_id`, `job_desc_id`, `job_desc_price`, `ai_column`) VALUES
('job_8', 'job_desc_1', '100.00', 4),
('job_8', 'job_desc_2', '110.00', 5),
('job_9', 'job_desc_1', '100.00', 7),
('job_10', 'job_desc_2', '110.00', 8),
('job_11', 'job_desc_1', '100.00', 9),
('job_12', 'job_desc_1', '100.00', 10),
('job_14', 'job_desc_1', '100.00', 12);

-- --------------------------------------------------------

--
-- Table structure for table `supplier_tb`
--

CREATE TABLE `supplier_tb` (
  `supplier_AI` int(11) NOT NULL,
  `supplier_id` varchar(20) AS (concat('supp_',supplier_AI)) VIRTUAL,
  `supplier_name` varchar(100) NOT NULL,
  `added_by_emp_id` varchar(20) NOT NULL DEFAULT 'Default'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `supplier_tb`
--

INSERT INTO `supplier_tb` (`supplier_AI`, `supplier_id`, `supplier_name`, `added_by_emp_id`) VALUES
(1, 'supp_1', 'Timeless Watch Parts supply', 'Default'),
(2, 'supp_2', 'Everlasting Incorporated', 'Default'),
(3, 'supp_3', 'Time Master Inc.', 'Default'),
(4, 'supp_4', 'New Period Era Delivery', 'Default'),
(5, 'supp_5', 'Time Stop Incorporated', 'Default');

-- --------------------------------------------------------

--
-- Table structure for table `temp_part_tb`
--

CREATE TABLE `temp_part_tb` (
  `item_id` varchar(20) NOT NULL,
  `item_quantity` int(11) NOT NULL,
  `item_price` decimal(13,2) NOT NULL,
  `window_id` varchar(100) NOT NULL,
  `ai_column` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `temp_svc_tb`
--

CREATE TABLE `temp_svc_tb` (
  `job_desc_id` varchar(50) NOT NULL,
  `job_desc_price` decimal(13,2) NOT NULL,
  `window_id` varchar(100) NOT NULL,
  `ai_column` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_type_tb`
--

CREATE TABLE `user_type_tb` (
  `user_type` int(11) NOT NULL,
  `user_type_remark` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user_type_tb`
--

INSERT INTO `user_type_tb` (`user_type`, `user_type_remark`) VALUES
(2, 'Admin'),
(1, 'Employee');

-- --------------------------------------------------------

--
-- Table structure for table `warranty_job_tb`
--

CREATE TABLE `warranty_job_tb` (
  `job_id` varchar(50) NOT NULL,
  `warranty_expire` date NOT NULL,
  `warranty_remark` varchar(200) NOT NULL DEFAULT 'No warranty'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `warranty_job_tb`
--

INSERT INTO `warranty_job_tb` (`job_id`, `warranty_expire`, `warranty_remark`) VALUES
('job_14', '2017-04-05', '7 days of warranty');

-- --------------------------------------------------------

--
-- Table structure for table `warranty_type_tb`
--

CREATE TABLE `warranty_type_tb` (
  `warranty_AI` int(11) NOT NULL,
  `warranty_type` varchar(30) AS (concat('warr_',warranty_AI)) VIRTUAL,
  `warranty_type_remark` varchar(100) NOT NULL,
  `warranty_day` int(10) UNSIGNED NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `warranty_type_tb`
--

INSERT INTO `warranty_type_tb` (`warranty_AI`, `warranty_type`, `warranty_type_remark`, `warranty_day`) VALUES
(1, 'warr_1', '7 Days Warranty', 7),
(2, 'warr_2', '1 Year Warranty', 365),
(3, 'warr_3', 'No Warranty', 0);

-- --------------------------------------------------------

--
-- Table structure for table `watch_build_tb`
--

CREATE TABLE `watch_build_tb` (
  `watch_build` int(11) NOT NULL,
  `watch_build_remark` varchar(70) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `watch_build_tb`
--

INSERT INTO `watch_build_tb` (`watch_build`, `watch_build_remark`) VALUES
(1, 'Gold'),
(2, 'Silver');

-- --------------------------------------------------------

--
-- Table structure for table `watch_kind_tb`
--

CREATE TABLE `watch_kind_tb` (
  `watch_kind` int(11) NOT NULL,
  `watch_kind_desc` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `watch_kind_tb`
--

INSERT INTO `watch_kind_tb` (`watch_kind`, `watch_kind_desc`) VALUES
(2, 'Ladies\' Watch'),
(1, 'Men\'s Watch');

-- --------------------------------------------------------

--
-- Table structure for table `window_maker_tb`
--

CREATE TABLE `window_maker_tb` (
  `window_AI` int(11) NOT NULL,
  `window_id` varchar(100) AS (concat('window_',window_AI)) VIRTUAL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category_tb`
--
ALTER TABLE `category_tb`
  ADD PRIMARY KEY (`category_AI`),
  ADD UNIQUE KEY `category_AI_UNIQUE` (`category_AI`),
  ADD UNIQUE KEY `category_name_UNIQUE` (`category_name`);

--
-- Indexes for table `customer_tb`
--
ALTER TABLE `customer_tb`
  ADD PRIMARY KEY (`customer_AI`),
  ADD UNIQUE KEY `customer_AI_UNIQUE` (`customer_AI`);

--
-- Indexes for table `employee_tb`
--
ALTER TABLE `employee_tb`
  ADD PRIMARY KEY (`emp_AI`),
  ADD UNIQUE KEY `emp_no_UNIQUE` (`emp_AI`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `inventory_tb`
--
ALTER TABLE `inventory_tb`
  ADD PRIMARY KEY (`item_AI`),
  ADD UNIQUE KEY `item_no_UNIQUE` (`item_AI`);

--
-- Indexes for table `job_desc_tb`
--
ALTER TABLE `job_desc_tb`
  ADD PRIMARY KEY (`job_desc_AI`),
  ADD UNIQUE KEY `job_desc_AI_UNIQUE` (`job_desc_AI`);

--
-- Indexes for table `job_type_tb`
--
ALTER TABLE `job_type_tb`
  ADD PRIMARY KEY (`job_type`),
  ADD UNIQUE KEY `job_type_UNIQUE` (`job_type`),
  ADD UNIQUE KEY `job_type_desc_UNIQUE` (`job_type_remark`);

--
-- Indexes for table `login_tb`
--
ALTER TABLE `login_tb`
  ADD PRIMARY KEY (`acct_id`),
  ADD UNIQUE KEY `user_name_UNIQUE` (`username`);

--
-- Indexes for table `part_tb`
--
ALTER TABLE `part_tb`
  ADD PRIMARY KEY (`part_AI`),
  ADD UNIQUE KEY `part_AI_UNIQUE` (`part_AI`),
  ADD UNIQUE KEY `part_name_UNIQUE` (`part_name`);

--
-- Indexes for table `position_type_tb`
--
ALTER TABLE `position_type_tb`
  ADD PRIMARY KEY (`position_type`);

--
-- Indexes for table `repair_job_tb`
--
ALTER TABLE `repair_job_tb`
  ADD PRIMARY KEY (`job_AI`),
  ADD UNIQUE KEY `job_AI_UNIQUE` (`job_AI`);

--
-- Indexes for table `repair_part_tb`
--
ALTER TABLE `repair_part_tb`
  ADD PRIMARY KEY (`ai_column`),
  ADD UNIQUE KEY `ai_column` (`ai_column`);

--
-- Indexes for table `repair_status_tb`
--
ALTER TABLE `repair_status_tb`
  ADD PRIMARY KEY (`repair_status_id`),
  ADD UNIQUE KEY `repair_status_id_UNIQUE` (`repair_status_id`),
  ADD UNIQUE KEY `repair_status_remark_UNIQUE` (`repair_status_remark`);

--
-- Indexes for table `repair_svc_tb`
--
ALTER TABLE `repair_svc_tb`
  ADD PRIMARY KEY (`ai_column`),
  ADD UNIQUE KEY `ai_column` (`ai_column`);

--
-- Indexes for table `supplier_tb`
--
ALTER TABLE `supplier_tb`
  ADD PRIMARY KEY (`supplier_AI`),
  ADD UNIQUE KEY `supplier_AI_UNIQUE` (`supplier_AI`),
  ADD UNIQUE KEY `supplier_name_UNIQUE` (`supplier_name`);

--
-- Indexes for table `temp_part_tb`
--
ALTER TABLE `temp_part_tb`
  ADD PRIMARY KEY (`ai_column`),
  ADD UNIQUE KEY `ai_column` (`ai_column`);

--
-- Indexes for table `temp_svc_tb`
--
ALTER TABLE `temp_svc_tb`
  ADD PRIMARY KEY (`ai_column`),
  ADD UNIQUE KEY `ai_column` (`ai_column`);

--
-- Indexes for table `user_type_tb`
--
ALTER TABLE `user_type_tb`
  ADD PRIMARY KEY (`user_type`),
  ADD UNIQUE KEY `emp_type_UNIQUE` (`user_type`),
  ADD UNIQUE KEY `emp_desc_UNIQUE` (`user_type_remark`);

--
-- Indexes for table `warranty_job_tb`
--
ALTER TABLE `warranty_job_tb`
  ADD PRIMARY KEY (`job_id`),
  ADD UNIQUE KEY `job_id_UNIQUE` (`job_id`);

--
-- Indexes for table `warranty_type_tb`
--
ALTER TABLE `warranty_type_tb`
  ADD PRIMARY KEY (`warranty_AI`),
  ADD UNIQUE KEY `warranty_AI_UNIQUE` (`warranty_AI`),
  ADD UNIQUE KEY `warranty_type_remark` (`warranty_type_remark`);

--
-- Indexes for table `watch_build_tb`
--
ALTER TABLE `watch_build_tb`
  ADD PRIMARY KEY (`watch_build`);

--
-- Indexes for table `watch_kind_tb`
--
ALTER TABLE `watch_kind_tb`
  ADD PRIMARY KEY (`watch_kind`),
  ADD UNIQUE KEY `watch_kind_UNIQUE` (`watch_kind`),
  ADD UNIQUE KEY `watch_kind_desc_UNIQUE` (`watch_kind_desc`);

--
-- Indexes for table `window_maker_tb`
--
ALTER TABLE `window_maker_tb`
  ADD PRIMARY KEY (`window_AI`),
  ADD UNIQUE KEY `window_AI_UNIQUE` (`window_AI`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category_tb`
--
ALTER TABLE `category_tb`
  MODIFY `category_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `customer_tb`
--
ALTER TABLE `customer_tb`
  MODIFY `customer_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `employee_tb`
--
ALTER TABLE `employee_tb`
  MODIFY `emp_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `inventory_tb`
--
ALTER TABLE `inventory_tb`
  MODIFY `item_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `job_desc_tb`
--
ALTER TABLE `job_desc_tb`
  MODIFY `job_desc_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `job_type_tb`
--
ALTER TABLE `job_type_tb`
  MODIFY `job_type` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `login_tb`
--
ALTER TABLE `login_tb`
  MODIFY `acct_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `part_tb`
--
ALTER TABLE `part_tb`
  MODIFY `part_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `repair_job_tb`
--
ALTER TABLE `repair_job_tb`
  MODIFY `job_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `repair_part_tb`
--
ALTER TABLE `repair_part_tb`
  MODIFY `ai_column` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `repair_svc_tb`
--
ALTER TABLE `repair_svc_tb`
  MODIFY `ai_column` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT for table `supplier_tb`
--
ALTER TABLE `supplier_tb`
  MODIFY `supplier_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `temp_part_tb`
--
ALTER TABLE `temp_part_tb`
  MODIFY `ai_column` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `temp_svc_tb`
--
ALTER TABLE `temp_svc_tb`
  MODIFY `ai_column` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `warranty_type_tb`
--
ALTER TABLE `warranty_type_tb`
  MODIFY `warranty_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `watch_build_tb`
--
ALTER TABLE `watch_build_tb`
  MODIFY `watch_build` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `window_maker_tb`
--
ALTER TABLE `window_maker_tb`
  MODIFY `window_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
