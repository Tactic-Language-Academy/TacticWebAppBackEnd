document.addEventListener("DOMContentLoaded", function () {
    const apiUrl = "http://localhost:5004/api/students"; // Update with your API URL
    const studentTableBody = document.getElementById("studentTableBody");
    const addStudentForm = document.getElementById("addStudentForm");

    // Function to Fetch Students from Backend
    function fetchStudents() {
        fetch(apiUrl)
            .then(response => response.json())
            .then(data => {
                studentTableBody.innerHTML = ""; // Clear table before adding new rows
                data.forEach(student => {
                    const row = `<tr>
                        <td>${student.id}</td>
                        <td>${student.studentName}</td>
                        <td>
                            <button class="btn btn-danger btn-sm" onclick="deleteStudent(${student.id})">Delete</button>
                        </td>
                    </tr>`;
                    studentTableBody.innerHTML += row;
                });
            })
            .catch(error => console.error("Error fetching students:", error));
    }

    // Function to Add a New Student
    addStudentForm.addEventListener("submit", function (event) {
        event.preventDefault();
        const studentName = document.getElementById("studentName").value;

        fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ studentName: studentName })
        })
            .then(response => response.json())
            .then(() => {
                fetchStudents();
                addStudentForm.reset();
            })
            .catch(error => console.error("Error adding student:", error));
    });

    // Function to Delete a Student
    window.deleteStudent = function (id) {
        fetch(`${apiUrl}/${id}`, { method: "DELETE" })
            .then(() => fetchStudents())
            .catch(error => console.error("Error deleting student:", error));
    };

    // Load Students on Page Load
    fetchStudents();
});
