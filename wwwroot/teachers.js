document.addEventListener("DOMContentLoaded", function () {
    const apiUrl = "http://localhost:5004/api/teachers";
    const scoresTableBody = document.getElementById("scoresTableBody");

    // Fetch students with their scores
    function fetchStudents() {
        fetch(`${apiUrl}/students-with-scores`)
            .then(response => response.json())
            .then(data => {
                scoresTableBody.innerHTML = ""; // Clear table before adding new rows
                data.forEach(student => {
                    const row = `<tr>
                        <td>${student.id}</td>
                        <td>${student.studentName}</td>
                        <td><input type="number" id="score-${student.id}" value="${student.Score || ''}" min="0" max="100"></td>
                        <td>
                            <button type="button" class="btn btn-primary btn-sm" onclick="submitScore(${student.id})">Submit</button>
                        </td>
                    </tr>`;
                    scoresTableBody.innerHTML += row;
                });
            })
            .catch(error => console.error("Error fetching students:", error));
    }

    // Function to Submit a Score
    window.submitScore = function (studentId) {
        const scoreValue = document.getElementById(`score-${studentId}`).value;
        if (scoreValue === "") {
            alert("Please enter a score.");
            return;
        }

        fetch(`${apiUrl}/submit-score`, {
            method: "PUT", // Changed to PUT for updating an existing score
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ studentId: studentId, score: parseFloat(scoreValue) })
        })
            .then(response => response.json())
            .then(data => {
                alert("Score submitted successfully!");
                fetchStudents(); // Refresh scores
            })
            .catch(error => console.error("Error submitting score:", error));
    };

    // Load Students on Page Load
    fetchStudents();
});
