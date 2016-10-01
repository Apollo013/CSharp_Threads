# CSharp_Threads

---

A couple of console apps demonstrating the basics of threading including thread types, joins, creation &amp; pooling..

---
###Features

|Feature |Description |
|--------|------------|
|Thread Types | Demonstrates how to create foreground & background threads |
|Thread Creation | Demonstrates how to create threads using Thread Class, ThreadStart delegate, Parameterized Thread, Anonymous Delegates, and Lambda Expressions. |
|Thread Pool | Demonstrates ThreadPool.QueueUserWorkItem, ManualResetEvent & WaitHandle |
|Exception Handling | Demonstrates how and where to catch exceptions |
|Thread Priority | Example showing thread execution with different priorities set (Highest & Lowest) |
|Thread Synchronization & Blocking | Example demonstrates Thread.Sleep, Thread.Join & Task.Wait |
|Thread Locking | Demonstrates how to lock a critical section of code to prevent simultaneous execution by multiple threads  |
|Thread Monitoring | Similar to Locking but gives you added control. Demonstrates Enter, Exit, Pulse & Wait.  |
|Thread Pausing and Resuming | Shows how to Start, Pause, Interrupt adn Abort Threads.  |
| Deadlock | Demonstrates how a deadlock between multiple threads can occur |
| Mutex | Demonstrates several examples of mutual exclusion when synchronizing |
| Context Synchronization | Demonstrates how to create thread safe classes using the 'Synchronization' key word and 'ContextBoundObject' inheritance  |
| ConcurrentDictionary | Demonstrates how to create thread safe classes using the 'Synchronization' key word and 'ContextBoundObject' inheritance  |
| Join Method | Another blocking mechanism example |
| ManualResetEvent | Signalling example allowing one thread to communicate with another |
| AutoResetEvent | Signalling example allowing one thread to communicate with another |

---
###Resources
| Title | Author |Website |
|--------------|--------|--------|
| [Threading in C#](http://www.albahari.com/threading/) | Joe Albahari | albahari.com |
| [Threading Simplified Parts 1 - 14](http://www.c-sharpcorner.com/UploadFile/19b1bd/threading-simplified-part1/)| |C# Corner |
| [Lock Statement](https://msdn.microsoft.com/en-us/library/c5kehkcz.aspx?f=255&MSPPError=-2147217396)| |MSDN |
| [Thread Synchronization](https://msdn.microsoft.com/en-us/library/mt679037.aspx?f=255&MSPPError=-2147217396)| |MSDN |
| [Threading with Monitor](http://www.c-sharpcorner.com/UploadFile/1d42da/threading-with-monitor-in-C-Sharp/)| |C# Corner|
| [Pausing and Resuming Threads](https://msdn.microsoft.com/en-us/library/tttdef8x%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396)||MSDN|
| [Mutex Class](https://msdn.microsoft.com/en-us/library/system.threading.mutex%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396)| |MSDN|

---

##Revisited Project

---

###Features
|Feature |Description |
|--------|------------|
|Race Conditions | Demonstrates thread synchronization using Join, lock & Monitor |

---

###Resources
|Title | Author |Website |
|--------------|--------|--------|
| [Race Conditions](http://www.csharpstar.com/csharp-race-conditions-in-threading/) |  | Csharpstar.com |
| [Locks and exceptions do not mix](https://blogs.msdn.microsoft.com/ericlippert/2009/03/06/locks-and-exceptions-do-not-mix/) | Eric Lippert | MSDN |
| [Subtleties of C# IL codegen](https://blogs.msdn.microsoft.com/ericlippert/2007/08/17/subtleties-of-c-il-codegen/) | Eric Lippert | MSDN |
