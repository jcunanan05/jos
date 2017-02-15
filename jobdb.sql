-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 15, 2017 at 03:29 PM
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
(1, 'emp_1', 'Jonathan Albert M. Cunanan', '50cj', 1);

-- --------------------------------------------------------

--
-- Table structure for table `inventory_tb`
--

CREATE TABLE `inventory_tb` (
  `item_AI` int(11) NOT NULL,
  `item_id` varchar(20) AS (concat('item_',item_AI)) VIRTUAL,
  `item_name` varchar(100) NOT NULL,
  `item_quantity` int(11) NOT NULL DEFAULT '0',
  `item_price` decimal(13,2) NOT NULL,
  `critical_amount` int(11) NOT NULL DEFAULT '0',
  `added_by_emp_id` varchar(20) NOT NULL,
  `supplier_id` varchar(20) NOT NULL,
  `category_id` varchar(20) NOT NULL,
  `part_id` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

-- --------------------------------------------------------

--
-- Table structure for table `job_type_tb`
--

CREATE TABLE `job_type_tb` (
  `job_type` int(11) NOT NULL,
  `job_type_remark` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
('50cj', '8fe4c11451281c094a6578e6ddbf5eed', 1, 1);

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

-- --------------------------------------------------------

--
-- Table structure for table `position_type_tb`
--

CREATE TABLE `position_type_tb` (
  `position_type` int(11) NOT NULL,
  `position_type_remark` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `repair_job_tb`
--

CREATE TABLE `repair_job_tb` (
  `job_AI` int(11) NOT NULL,
  `job_id` varchar(50) AS (concat('job_',job_AI)) VIRTUAL,
  `date_time_added` datetime NOT NULL,
  `customer_id` varchar(30) NOT NULL,
  `job_type` int(11) NOT NULL,
  `total_price` decimal(13,2) NOT NULL,
  `warranty_type` varchar(30) NOT NULL DEFAULT 'warr_0',
  `warranty_remark` varchar(45) NOT NULL DEFAULT 'No warranty',
  `watch_serial_no` varchar(100) NOT NULL,
  `watch_kind` int(11) NOT NULL,
  `watch_build` int(11) NOT NULL,
  `watch_remark` varchar(500) NOT NULL,
  `technician_id` varchar(20) DEFAULT NULL,
  `repair_status_id` int(11) DEFAULT '1',
  `start_repair_date` date NOT NULL,
  `expected_claim_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `repair_part_tb`
--

CREATE TABLE `repair_part_tb` (
  `job_id` varchar(50) NOT NULL,
  `item_id` varchar(20) NOT NULL,
  `item_quantity` int(11) NOT NULL,
  `item_price` decimal(13,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
  `job_desc_id` varchar(50) NOT NULL,
  `job_desc_price` decimal(13,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

-- --------------------------------------------------------

--
-- Table structure for table `temp_part_tb`
--

CREATE TABLE `temp_part_tb` (
  `item_id` varchar(20) NOT NULL,
  `item_quantity` int(11) NOT NULL,
  `item_price` decimal(13,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `temp_svc_tb`
--

CREATE TABLE `temp_svc_tb` (
  `job_desc_id` varchar(50) NOT NULL,
  `job_desc_price` decimal(13,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_type_tb`
--

CREATE TABLE `user_type_tb` (
  `user_type` int(11) NOT NULL,
  `user_type_remark` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `warranty_job_tb`
--

CREATE TABLE `warranty_job_tb` (
  `job_id` varchar(50) NOT NULL,
  `warranty_expire` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

-- --------------------------------------------------------

--
-- Table structure for table `watch_build_tb`
--

CREATE TABLE `watch_build_tb` (
  `watch_build` int(11) NOT NULL,
  `watch_build_remark` varchar(70) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `watch_kind_tb`
--

CREATE TABLE `watch_kind_tb` (
  `watch_kind` int(11) NOT NULL,
  `watch_kind_desc` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
  ADD UNIQUE KEY `emp_no_UNIQUE` (`emp_AI`);

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
  ADD PRIMARY KEY (`job_id`),
  ADD UNIQUE KEY `item_id_UNIQUE` (`item_id`);

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
  ADD PRIMARY KEY (`job_desc_id`);

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
  ADD PRIMARY KEY (`item_id`),
  ADD UNIQUE KEY `item_id_UNIQUE` (`item_id`);

--
-- Indexes for table `temp_svc_tb`
--
ALTER TABLE `temp_svc_tb`
  ADD PRIMARY KEY (`job_desc_id`);

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
  ADD UNIQUE KEY `warranty_AI_UNIQUE` (`warranty_AI`);

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
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category_tb`
--
ALTER TABLE `category_tb`
  MODIFY `category_AI` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `customer_tb`
--
ALTER TABLE `customer_tb`
  MODIFY `customer_AI` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `employee_tb`
--
ALTER TABLE `employee_tb`
  MODIFY `emp_AI` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `job_desc_tb`
--
ALTER TABLE `job_desc_tb`
  MODIFY `job_desc_AI` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `job_type_tb`
--
ALTER TABLE `job_type_tb`
  MODIFY `job_type` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `login_tb`
--
ALTER TABLE `login_tb`
  MODIFY `acct_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `part_tb`
--
ALTER TABLE `part_tb`
  MODIFY `part_AI` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `repair_job_tb`
--
ALTER TABLE `repair_job_tb`
  MODIFY `job_AI` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `supplier_tb`
--
ALTER TABLE `supplier_tb`
  MODIFY `supplier_AI` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `warranty_type_tb`
--
ALTER TABLE `warranty_type_tb`
  MODIFY `warranty_AI` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
