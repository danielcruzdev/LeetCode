namespace ReverseLinkedList_206;

class Program
{
    static void Main(string[] args)
    {
        // Example 1: [1,2,3,4,5] → [5,4,3,2,1]
        var head1 = new ListNode(1, new(2, new(3, new(4, new(5)))));
        PrintList(ReverseList(head1));

        // Example 2: [1,2] → [2,1]
        var head2 = new ListNode(1, new(2));
        PrintList(ReverseList(head2));

        // Example 3: [] → []
        ListNode head3 = null;
        PrintList(ReverseList(head3));
    }

    private static void PrintList(ListNode head)
    {
        var parts = new List<string>();
        while (head != null) { parts.Add(head.val.ToString()); head = head.next; }
        Console.WriteLine(parts.Count > 0 ? string.Join(" -> ", parts) : "(empty)");
    }

    private static ListNode ReverseList(ListNode head)
    {        
        ListNode prev = null;
        ListNode current = head;

        while (current != null)
        {
            ListNode nextTemp = current.next; // Store the next node
            current.next = prev; // Reverse the current node's pointer
            prev = current; // Move prev to the current node
            current = nextTemp; // Move to the next node
        }

        return prev; // At the end, prev will be the new head of the reversed list
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}