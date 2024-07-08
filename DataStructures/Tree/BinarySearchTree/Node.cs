﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructuresLibrary.Tree.BinarySearchTree
{
	public class Node<T>
	{
		public T? Value { get; set; }
		public Node<T>? Left { get; set; }
		public Node<T>? Right { get; set; }
        public Node()
        {
            
        }
        public Node(T value)
		{
			Value = value;
		}
		public override string ToString()
		{
			return $"{Value}";
		}
	}
}
