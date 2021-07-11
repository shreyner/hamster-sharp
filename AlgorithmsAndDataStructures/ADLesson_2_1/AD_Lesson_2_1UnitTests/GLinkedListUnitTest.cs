using System;
using Xunit;
using ADLesson_2_1;
using Xunit.Abstractions;

namespace AD_Lesson_2_1UnitTests
{
    public class GLinkedListUnitTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public GLinkedListUnitTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void AddNode_FirstNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var expected = new Node {Value = NODE_FIRST_VALUE, PrevNode = null, NextNode = null};

            linkedList.AddNode(NODE_FIRST_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expected),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void AddNode_SecondNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;

            var expectedListNode = new Node {Value = NODE_FIRST_VALUE, PrevNode = null, NextNode = null};
            expectedListNode.NextNode = new Node
                {Value = NODE_SECOND_VALUE, PrevNode = expectedListNode, NextNode = null};

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void AddNodeAfter_AfterFirstNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;

            var expectedListNode = new Node {Value = NODE_FIRST_VALUE, PrevNode = null, NextNode = null};
            expectedListNode.NextNode = new Node {Value = NODE_SECOND_VALUE, PrevNode = expectedListNode};

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNodeAfter(linkedList.GetList(), NODE_SECOND_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void AddNodeAfter_AfterMiddleNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_FOURTH_VALUE = 25;
            var NODE_AFTER_SECOND_VALUE = 30;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var SecondNode = new Node {Value = NODE_SECOND_VALUE};
            FirstNode.NextNode = SecondNode;
            SecondNode.PrevNode = FirstNode;

            var AfterSecondNode = new Node {Value = NODE_AFTER_SECOND_VALUE, PrevNode = SecondNode};
            SecondNode.NextNode = AfterSecondNode;

            var ThirdNode = new Node {Value = NODE_THIRD_VALUE, PrevNode = AfterSecondNode};
            AfterSecondNode.NextNode = ThirdNode;

            var FourthNode = new Node {Value = NODE_FOURTH_VALUE, PrevNode = ThirdNode};
            ThirdNode.NextNode = FourthNode;

            var expectedListNode = FirstNode;


            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);
            linkedList.AddNode(NODE_FOURTH_VALUE);


            linkedList.AddNodeAfter(linkedList.GetList().NextNode, NODE_AFTER_SECOND_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void AddNodeAfter_AfterLastNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_FOURTH_VALUE = 25;
            var NODE_AFTER_LAST_VALUE = 30;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var SecondNode = new Node {Value = NODE_SECOND_VALUE};
            FirstNode.NextNode = SecondNode;
            SecondNode.PrevNode = FirstNode;

            var ThirdNode = new Node {Value = NODE_THIRD_VALUE, PrevNode = SecondNode};
            SecondNode.NextNode = ThirdNode;

            var FourthNode = new Node {Value = NODE_FOURTH_VALUE, PrevNode = ThirdNode};
            ThirdNode.NextNode = FourthNode;

            var AfterLastNode = new Node {Value = NODE_AFTER_LAST_VALUE, PrevNode = FourthNode};
            FourthNode.NextNode = AfterLastNode;

            var expectedListNode = FirstNode;


            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);
            linkedList.AddNode(NODE_FOURTH_VALUE);


            linkedList.AddNodeAfter(linkedList.GetList().NextNode.NextNode.NextNode, NODE_AFTER_LAST_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_FirstNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;

            var SecondNode = new Node {Value = NODE_SECOND_VALUE};
            var ThirdNode = new Node {Value = NODE_THIRD_VALUE};
            SecondNode.NextNode = ThirdNode;
            ThirdNode.PrevNode = SecondNode;

            var expectedListNode = SecondNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);


            linkedList.RemoveNode(0);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_FirstNode_And_AddNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_ADD_FOURTH_VALUE = 25;

            var SecondNode = new Node {Value = NODE_SECOND_VALUE};
            var ThirdNode = new Node {Value = NODE_THIRD_VALUE};
            SecondNode.NextNode = ThirdNode;
            ThirdNode.PrevNode = SecondNode;

            var FourthNode = new Node {Value = NODE_ADD_FOURTH_VALUE, PrevNode = ThirdNode};
            ThirdNode.NextNode = FourthNode;

            var expectedListNode = SecondNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);


            linkedList.RemoveNode(0);
            linkedList.AddNode(NODE_ADD_FOURTH_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_FirstNode_And_AddNodeAfter_FirstNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_ADD_AFTER_NEW_FIRST_VALUE = 25;

            var SecondNode = new Node {Value = NODE_SECOND_VALUE};
            var NewAfterSecondNode = new Node {Value = NODE_ADD_AFTER_NEW_FIRST_VALUE, PrevNode = SecondNode};
            SecondNode.NextNode = NewAfterSecondNode;

            var ThirdNode = new Node {Value = NODE_THIRD_VALUE, PrevNode = NewAfterSecondNode};
            NewAfterSecondNode.NextNode = ThirdNode;

            var expectedListNode = SecondNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);


            linkedList.RemoveNode(0);
            linkedList.AddNodeAfter(linkedList.GetList(), NODE_ADD_AFTER_NEW_FIRST_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_FirstNode_And_AddNodeAfter_LastNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_ADD_AFTER_NEW_Last_VALUE = 25;

            var SecondNode = new Node {Value = NODE_SECOND_VALUE};
            var ThirdNode = new Node {Value = NODE_THIRD_VALUE, PrevNode = SecondNode};
            SecondNode.NextNode = ThirdNode;

            var NewAfterLastNode = new Node {Value = NODE_ADD_AFTER_NEW_Last_VALUE, PrevNode = ThirdNode};
            ThirdNode.NextNode = NewAfterLastNode;


            var expectedListNode = SecondNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);


            linkedList.RemoveNode(0);
            linkedList.AddNodeAfter(linkedList.GetList().NextNode, NODE_ADD_AFTER_NEW_Last_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_MiddleNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var ThirdNode = new Node {Value = NODE_THIRD_VALUE};
            FirstNode.NextNode = ThirdNode;
            ThirdNode.PrevNode = FirstNode;

            var expectedListNode = FirstNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);


            linkedList.RemoveNode(1);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_MiddleNode_And_AddNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_ADD_FOURTH_VALUE = 25;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var ThirdNode = new Node {Value = NODE_THIRD_VALUE};
            FirstNode.NextNode = ThirdNode;
            ThirdNode.PrevNode = FirstNode;

            var FourthNode = new Node {Value = NODE_ADD_FOURTH_VALUE, PrevNode = ThirdNode};
            ThirdNode.NextNode = FourthNode;

            var expectedListNode = FirstNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);


            linkedList.RemoveNode(1);
            linkedList.AddNode(NODE_ADD_FOURTH_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_MiddleNode_And_AddNodeAfter_FirstNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_ADD_FOURTH_VALUE = 25;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var AddFourthNode = new Node {Value = NODE_ADD_FOURTH_VALUE, PrevNode = FirstNode};
            var ThirdNode = new Node {Value = NODE_THIRD_VALUE, PrevNode = AddFourthNode};
            FirstNode.NextNode = AddFourthNode;
            AddFourthNode.NextNode = ThirdNode;

            var expectedListNode = FirstNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);


            linkedList.RemoveNode(1);
            linkedList.AddNodeAfter(linkedList.GetList(), NODE_ADD_FOURTH_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_MiddleNode_And_AddNodeAfter_LastNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_ADD_AFTER_NEW_Last_VALUE = 25;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var ThirdNode = new Node {Value = NODE_THIRD_VALUE, PrevNode = FirstNode};
            FirstNode.NextNode = ThirdNode;

            var NewAfterLastNode = new Node {Value = NODE_ADD_AFTER_NEW_Last_VALUE, PrevNode = ThirdNode};
            ThirdNode.NextNode = NewAfterLastNode;


            var expectedListNode = FirstNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);


            linkedList.RemoveNode(1);

            linkedList.AddNodeAfter(linkedList.GetList().NextNode, NODE_ADD_AFTER_NEW_Last_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }


        [Fact]
        public void RemoveByIndex_LastNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var SecondNode = new Node {Value = NODE_SECOND_VALUE};
            FirstNode.NextNode = SecondNode;
            SecondNode.PrevNode = FirstNode;

            var expectedListNode = FirstNode;


            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);

            linkedList.RemoveNode(2);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_LastNode_And_AddNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_ADD_FOURTH_VALUE = 25;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var SecondNode = new Node {Value = NODE_SECOND_VALUE, PrevNode = FirstNode};
            FirstNode.NextNode = SecondNode;

            var FourthNode = new Node {Value = NODE_ADD_FOURTH_VALUE, PrevNode = SecondNode};
            SecondNode.NextNode = FourthNode;

            var expectedListNode = FirstNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);

            linkedList.RemoveNode(2);
            linkedList.AddNode(NODE_ADD_FOURTH_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_LastNode_And_AddNodeAfter_FirstNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_ADD_FOURTH_VALUE = 25;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var AddFourthNode = new Node {Value = NODE_ADD_FOURTH_VALUE, PrevNode = FirstNode};
            FirstNode.NextNode = AddFourthNode;
            var SecondNode = new Node {Value = NODE_SECOND_VALUE, PrevNode = AddFourthNode};
            AddFourthNode.NextNode = SecondNode;

            var expectedListNode = FirstNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);

            linkedList.RemoveNode(2);
            linkedList.AddNodeAfter(linkedList.GetList(), NODE_ADD_FOURTH_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void RemoveByIndex_LastNode_And_AddNodeAfter_LastNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;
            var NODE_ADD_AFTER_NEW_Last_VALUE = 25;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var SecondNode = new Node {Value = NODE_SECOND_VALUE, PrevNode = FirstNode};
            FirstNode.NextNode = SecondNode;

            var AddFourthNode = new Node {Value = NODE_ADD_AFTER_NEW_Last_VALUE, PrevNode = SecondNode};
            SecondNode.NextNode = AddFourthNode;

            var expectedListNode = FirstNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);

            linkedList.RemoveNode(2);

            linkedList.AddNodeAfter(linkedList.GetList().NextNode, NODE_ADD_AFTER_NEW_Last_VALUE);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        /// <summary>
        ///  ====
        /// </summary>
        [Fact]
        public void RemoveByIndex_IndexedMoreCount_ShouldException()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);

            Action action = () => linkedList.RemoveNode(3);

            Assert.ThrowsAny<ArgumentException>(action);
        }

        [Fact]
        public void RemoveByIndex_IndexedLess0_ShouldException()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);

            Action action = () => linkedList.RemoveNode(-1);

            Assert.ThrowsAny<ArgumentException>(action);
        }

        [Fact]
        public void RemoveNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;

            var FirstNode = new Node {Value = NODE_FIRST_VALUE};
            var ThirdNode = new Node {Value = NODE_THIRD_VALUE, PrevNode = FirstNode};
            FirstNode.NextNode = ThirdNode;

            var expectedListNode = FirstNode;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);

            linkedList.RemoveNode(linkedList.GetList().NextNode);

            var actual = linkedList.GetList();

            Assert.Equal(
                NodeUtilTesting.GetChainingValueFromFirstToLast(expectedListNode),
                NodeUtilTesting.GetChainingValueFromFirstToLast(actual)
            );
        }

        [Fact]
        public void FindNode()
        {
            var linkedList = new GLinkedList();
            var NODE_FIRST_VALUE = 10;
            var NODE_SECOND_VALUE = 15;
            var NODE_THIRD_VALUE = 20;

            var NODE_FIND_TARGET_VALUE = NODE_SECOND_VALUE;

            linkedList.AddNode(NODE_FIRST_VALUE);
            linkedList.AddNode(NODE_SECOND_VALUE);
            linkedList.AddNode(NODE_THIRD_VALUE);

            Assert.Equal(
                linkedList.FindNode(NODE_FIND_TARGET_VALUE).Value,
                NODE_FIND_TARGET_VALUE
            );
        }
    }
}