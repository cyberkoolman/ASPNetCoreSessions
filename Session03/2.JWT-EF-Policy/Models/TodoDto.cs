public record TodoDto (
                int Id, 
                string TaskTitle, 
                string TaskDesc, 
                bool IsComplete, 
                string TaskTo
            );