-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 08, 2020 at 05:19 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kong_bu_bank`
--

-- --------------------------------------------------------

--
-- Table structure for table `banktransaction`
--

CREATE TABLE `banktransaction` (
  `id` varchar(255) NOT NULL,
  `transactiontype` varchar(255) NOT NULL,
  `amount` int(11) NOT NULL,
  `division` varchar(255) NOT NULL,
  `transactiondate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `banktransaction`
--

INSERT INTO `banktransaction` (`id`, `transactiontype`, `amount`, `division`, `transactiondate`) VALUES
('CH001', 'Repair Cost', 10000, 'Security & Maintenance Team', '2020-12-05'),
('CM001', 'Repair Cost', 90000, 'Security & Maintenance Team', '2020-12-05');

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `accountnumber` varchar(255) NOT NULL,
  `pin` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `identitycard` varchar(255) NOT NULL,
  `familycard` varchar(255) NOT NULL,
  `Balance` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`accountnumber`, `pin`, `name`, `identitycard`, `familycard`, `Balance`) VALUES
('2020260801', '123456', 'Gaby', 'IC001', 'FC001', 16193524),
('2020260802', '123456', 'Mama Gaby', 'IC002', 'FC001', 6846421),
('2020260803', '123456', 'Papa Gaby', 'IC003', 'FC001', 9876659),
('2020260804', '123456', 'Stanley', 'IC004', 'FC002', 23575264),
('2020260805', '123456', 'Dave', 'IC005', 'FC003', 1500000);

-- --------------------------------------------------------

--
-- Table structure for table `deposit`
--

CREATE TABLE `deposit` (
  `accountnumber` varchar(255) NOT NULL,
  `depositmoney` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `deposit`
--

INSERT INTO `deposit` (`accountnumber`, `depositmoney`) VALUES
('2020260803', 500000),
('2020260801', 475001),
('2020260801', 375001),
('2020260801', 300001),
('2020260801', 220001),
('2020260801', 150001),
('2020260801', 50000);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `id` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `salary` int(11) NOT NULL,
  `rating` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`id`, `name`, `password`, `salary`, `rating`) VALUES
('T001', 'Clarissa', 'password', 5000000, 4.9),
('T002', 'Chuardi', 'password', 5000000, 4.9),
('T003', 'Clarissa Chuardi', 'password', 4800000, 4.9),
('T004', 'Chuardi Clarissa', 'password', 4500000, 4.9),
('CS001', 'Corinne', 'password', 4000000, 5),
('CS002', 'Bailey', 'password', 4500000, 5),
('SM001', 'Mimi', 'password', 5000000, 4.99),
('SM002', 'Peri', 'password', 6000000, 5);

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

CREATE TABLE `item` (
  `itemid` varchar(255) NOT NULL,
  `itemname` varchar(255) NOT NULL,
  `itemstatus` varchar(255) NOT NULL,
  `employee` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `item`
--

INSERT INTO `item` (`itemid`, `itemname`, `itemstatus`, `employee`) VALUES
('CM001', 'Computer', 'OK', 'T001'),
('MC001', 'Money Counter', 'OK', 'T001'),
('TB001', 'Table', 'OK', 'T001'),
('CH001', 'Chair', 'OK', 'T001'),
('CM002', 'Computer', 'OK', 'T002'),
('MC002', 'Money Counter', 'Broken', 'T002'),
('TB002', 'Table', 'OK', 'T002'),
('CH002', 'Chair', 'OK', 'T002'),
('CM003', 'Computer', 'OK', 'T003'),
('MC003', 'Money Counter', 'OK', 'T003'),
('TB003', 'Table', 'OK', 'T003'),
('CH003', 'Chair', 'OK', 'T003'),
('CM004', 'Computer', 'OK', 'T004'),
('MC004', 'Money Counter', 'Broken', 'T004'),
('TB004', 'Table', 'OK', 'T004'),
('CH004', 'Chair', 'OK', 'T004'),
('ATM001', 'ATM Machine', 'OK', 'SM'),
('ATM002', 'ATM Machine', 'OK', 'SM'),
('ATM003', 'ATM Machine', 'OK', 'SM'),
('ATM004', 'ATM Machine', 'OK', 'SM');

-- --------------------------------------------------------

--
-- Table structure for table `schedule`
--

CREATE TABLE `schedule` (
  `itemid` varchar(255) NOT NULL,
  `itemname` varchar(255) NOT NULL,
  `schedule` date NOT NULL,
  `repairstatus` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `schedule`
--

INSERT INTO `schedule` (`itemid`, `itemname`, `schedule`, `repairstatus`) VALUES
('MC002', 'Teller Money Counter', '2020-12-06', 'Not Fixed'),
('MC004', 'Teller Money Counter', '2020-12-07', 'Not Fixed');

-- --------------------------------------------------------

--
-- Table structure for table `teller`
--

CREATE TABLE `teller` (
  `tellerid` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `salary` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `teller`
--

INSERT INTO `teller` (`tellerid`, `password`, `salary`) VALUES
('T001', 'password', 5000000),
('T002', 'password', 5000000),
('T003', 'password', 4200000),
('T004', 'password', 4800000);

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `sender` varchar(255) DEFAULT NULL,
  `senderaccnum` varchar(255) DEFAULT NULL,
  `transactiontype` varchar(255) NOT NULL,
  `amount` int(11) NOT NULL,
  `receiver` varchar(255) NOT NULL,
  `note` varchar(255) DEFAULT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`sender`, `senderaccnum`, `transactiontype`, `amount`, `receiver`, `note`, `date`) VALUES
('Papa Gaby', '2020260803', 'Deposit Money', 101, '2020260801', '', '2020-12-01'),
('Gaby', '2020260801', 'Deposit Money', 50000, '2020260801', '', '2020-12-01'),
('Gaby', '2020260801', 'Transfer Money', 10000, '101010', 'uang shoppee\r\n', '2020-12-01'),
('Gaby', '', 'Withdraw Money', 4000000, '', '', '2020-12-01'),
('', '', 'Withdraw Money', 10000000, 'Gaby', '', '2020-12-01'),
('', '', 'Withdraw Money', 10000, 'Gaby', '', '2020-12-01'),
('Papa Gaby', '2020260803', 'Transfer Money', 1119, '2020260801', '', '2020-12-02'),
('Papa Gaby', '2020260803', 'Transfer Money', 22222, '10101001', '', '2020-12-02'),
('Gaby', '2020260801', 'Transfer Money', 123, '2020260801', '', '2020-12-02'),
('Gaby', '2020260801', 'Transfer Money', 123, '2020260801', '', '2020-12-02'),
('Gaby', '2020260801', 'Transfer Money', 456, '2020260801', '', '2020-12-02'),
('Gaby', '2020260801', 'Transfer Money', 456, '2020260801', '', '2020-12-02'),
('Papa Gaby', '2020260803', 'Deposit Money', 500000, '2020260803', '', '2020-12-02'),
('Papa Gaby', '2020260803', 'Deposit Money', 100000, '2020260801', '', '2020-12-02'),
('Clarissa', '', 'Transfer Money', 141244, '2020260804', '-\r\n', '2020-12-02'),
('Mama Gaby', '2020260802', 'Transfer Money', 10000, '2020260801', '', '2020-12-03'),
('Mama Gaby', '2020260802', 'Deposit Money', 75000, '2020260801', '', '2020-12-03'),
('', '', 'Withdraw Money', 50000, '2020260803', '', '2020-12-03'),
('Mama Gaby', '2020260802', 'Payments', 70000, '2020260803', 'Phone Bill', '2020-12-03'),
('Clarissa', '', 'Payments', 101, '10101', 'Electric Bill', '2020-12-03'),
('Clarissa', '', 'Payments', 45000, '123123', 'Electric Bill', '2020-12-03'),
('Mama Gaby', '2020260802', 'Payments', 123, '123', 'Electric Bill', '2020-12-03'),
('Mama Gaby', '2020260802', 'Payments', 123456, '123456', 'E-Commerce', '2020-12-03'),
('Gaby', '2020260801', 'Payments', 9049019, '31232', 'Phone Bill', '2020-12-04'),
('clarissa', NULL, 'Transfer Money', 100000, '2020260801', NULL, '2020-11-19'),
('Mama Gaby', '2020260802', 'Deposit Money', 80000, '2020260801', '', '2020-12-07'),
('Gaby', '2020260801', 'Deposit Money', 70000, '2020260801', '', '2020-12-07'),
('Mama Gaby', '2020260802', 'Deposit Money', 100000, '2020260801', '', '2020-12-07'),
('Mama Gaby', '2020260802', 'Deposit Money', 50000, '2020260801', '', '2020-12-07'),
('Stanley', '2020260804', 'Transfer Money', 50000, '2020260801', '-\r\n', '2020-12-07'),
('Stanley', '2020260804', 'Transfer Money', 1, '2020260801', '\r\n', '2020-12-07'),
('', '', 'Withdraw Money', 100000, 'Gaby', '', '2020-12-07'),
('Gaby', '2020260801', 'Payments', 1, '12313', '-\r\n', '2020-12-07');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD UNIQUE KEY `identitycard` (`identitycard`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
