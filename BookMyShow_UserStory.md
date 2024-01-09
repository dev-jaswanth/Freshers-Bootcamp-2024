# User Story of Book My show:
I want to be able to book tickets for movies events and shows easily and efficiently so that I can have a seamless booking experience.



# Understanding NFR's and Quality attribute

**Non functional requirements** are usually referred to as NFR with words ending with itys(eg. Availability,security,etc.)

Nonfunctional rerquirements can be mistaken with quality attributes. Quality attributes are  necessary characteristics of a product. Whereas Non-functional requirement is the measure and criteria of such characteristics.

Secure is a quality attribute while defining explicit requirements values for “security” is a non-functional requirement.

##  **Functional Requirements**

- The website should allow the users to book tickets Online.
- **Concurrency Handling**: If one user is booking and the payment is not completed then the other user should not be able to see the tickets. We must handle this thing at both application and database level. It is done using pessimistic lock in spring JPA. (This must be a Functional Requirement for an Online reservation platform).

## Non Functional Requirements
- **Performance**: The system should load the website and mobile app within 2 seconds to ensure fast.
- **High availability**: The platform should have an uptime of 99.99%.
- **Scalability**: The platform should be able to handle million users at a time.

## Quality attribute:
- User Experience

- Reliable and Available

- Secure and privacy (COTS).


[Use Case Diagram](https://viewer.diagrams.net/?tags=%7B%7D&highlight=0000ff&edit=_blank&layers=1&nav=1&title=uml_work.drawio#R7Vtdc6M2FP01fnQGEBjymI9Nu51NN9Nsd9unjgIyqAHkCjm299dXgIRBgsSJDTie5CXoIgQ%2b5%2bjq6l6YgKtk/QuFi%2biWBCieWEawnoDriWVZNjD4v9yyERYD2KUlpDgobebWcI9/ImEUF4ZLHKCs0ZEREjO8aBp9kqbIZw0bpJSsmt3mJG7edQFDpBnufRjr1h84YFFp9Rxja/8V4TCSdzYNceYB%2bo8hJctU3C8lKSrPJFAOI7pmEQzIqmYCnybgihLCyqNkfYXiHFeJWHndTcfZ6pEpStkuF/xA/9HvduTT5LenB5x8/vz19p%2bpGOUJxksBxdUyYyRBVDw020iM%2bPMv8sNlEl/4jNAJuHxClGGO4hf4gOI7kmGGScq7PBDGx6h1uIhxmJ9gZMGtEUti3jD5obg974bWnb/LrNDiCkT84Rjd8C7igqktaRLqm848YVhtuTQlDVGdRylcKPQTVqNvgeQHAstX4GppuF4ECU7fDaj2uYKpZ42OKdAwvUbZI7d8nc%2bx/44U67gKuM74grU1cDU4ayAElCy%2bQRqi/LkMblhFmKH7BfTzviu%2bShxoblumo%2bjwXIdqZrdANZv1BZXzMlRSeQkJlrnt8l/E2EYuLZ40VGuKvStc3dx1YmhqeLUpS9ooiiHDT811sQ1Ccb87gvmz1QhzG3y5zQHIfJ5xzagMVA/9dlJmGilfSJg73Bv%2bnyyZRhEfk0cXqEO7h53wYBdn2iZitzdf6mqAFFEMCsSEJpRFHLiUu0qSu8ACikK0InqDS0aaQKE1Zn/Vjv/OhzpzROt6LUYuGhvRKJ8CBVp4pkDLn5QsqY%2be%2bUluOwV7Clr31bbCCSv8oLjs8MJ2NWFfEvKI0/CoFO2OrugqzO5B0cY4ivZ6UfQUWGq8PLCkgXdyzqcfqkZ3Pp7mfO7gJkHpcS2nM3N052NqgLx353N%2bqs7n/OScTz9U6c7HGZapc835fMdoxS3HGAA5owdA0gk2ck4BN9ySJ4xGBctSpeS27OIH3gDZJ%2bcGzA4S9vQDtqeS5w3rB0w9SV0KO4vI6rh03Zp5HlbXzunp2jpRXVuarq9g6he1tfujk3ZrjnrYBU4vAFR4/U4YnmMfFun8MXEzVVUBe3Tc9Nz%2bn4sAMh4T3FQAHkNMZaqFPM9twa4te91brt/Uk/0XWZaXhjhKCI67D56aWpWuDbBhxaYn4v9A87w%2bPi5S2rQcPQK1rP5W6pFyBmY/OfjxkwZ2W81vBpNcqTErQKy3cOrHywBVxrDRRbTU6cAJKKrSTUahqEP7nAxUr2DLAnWCg6AoMVKU4Z/woRgv53WRg1HA41xOnOvnJpJ4rUZcPKmKgS9WHq2O0EwSZ5wBU3oEyZ2Q/Vs1sWm9oL/ColTaKQXUJ1oqM/Va2VHFN2rOqHpvbrzVusdKzGvWIA4g3VQzIm%2bUVwHlT57djlK0GsPcIYo5OrmzPPTEEZ6MyTdfOmHdc37tx2mPCe4T5NR9D5wCPQWme7I0uMhfheWt4i1UcBnALCpYN5tsNuWQ8Z/O5JV%2bDPn2xpfmGxzHdQZb6HRe4u8YQtJd%2bJ21E1zzzU6La5a2vd%2bb6kobyDHKX6qtndpI6iJTbXSGqq/pWa2DSfUtcVOlW%2bN1um1MC7JA6bcIp8q8GE2rYFStahKT26PXatVWB9oxA8tpgZtaN7HV6SP619MZHxu/apZ3RrrGmeEeZp83HWyjB0B/cdMhHNaRxU2y3Pyis%2bpQykCB0%2byD1FeQuusGp2P9GYZTu8dg%2bCDRwjNB9MiJH2dHfkeNhbWwwFG/etk1vrDU%2bogzcInXbvus5iN8EFP4ubyxAeR6LLiz99PWAIniHjc%2bPbqXt3q8Q7ole0e3ZBrtshnIL2lvsakvRO68R1d3%2b55xKL/Em9tPisvu22%2b2waf/AQ==)
