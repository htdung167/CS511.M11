import sqlite3 as lite
import re


f = open("./anhviet109K.txt", "r", encoding="utf8")
all_text = f.read()
f.close()

# con = None
# path = "./AnhViet.db"
# con = lite.connect(path)

# with con:
#     cur = con.cursor()
#     cur.execute

lst_w = all_text.split("\n\n")
lst_af_all = []
for i in range(len(lst_w)):
    try:
        lst_af = []
        s = lst_w[i].split("\n")
        if("/" in s[0]):
            lst_af.append(s[0].replace(re.findall("\s/.+/", s[0])[0], "")[1:])
        for i in range(1, len(s)):
            if s[i][0] == "=":
                s[i] = s[i].replace("=", "Ví dụ: ", 1)
                s[i] = s[i].replace("+", " =")
            elif s[i][0] == "!":
                s[i] = s[i].replace("!", "Cụm từ: ", 1)
        lst_af.append("\n".join(s[1:]))
        if("/" in s[0]):
            lst_af.append(re.findall("/.+/", s[0])[0])
        else:
            lst_af.append("")
        lst_af_all.append(lst_af)
    except:
        print("---Lỗi gì đó---")

print(len(lst_w), len(lst_af_all))

con = None
path = "./TuDien.db"
con = lite.connect(path)

sql = """INSERT INTO AnhViet VALUES(?, ?, ?)"""

for i in range(len(lst_af_all)):
    print(i)
    cur = con.cursor()
    try:
        cur.execute(sql, (lst_af_all[i][0], lst_af_all[i][1], lst_af_all[i][2]))
    except:
        print("---Lỗi gì đó---")
    cur.close()
con.commit()
con.close()

# cur = con.cursor()
# cur.execute("SELECT * FROM AnhViet")
# rows = cur.fetchall()
# cur.close()
# con.close()
# print(rows)


# print(lst_af_all[1136])
# cur = con.cursor()
# cur.execute("Select * from Main")
# rows = cur.fetchall()
# print(rows)
# print(lst_af_all)

# lst_af = []
# s = lst_w[1123].split("\n")
# print(s)
# print(re.findall("/.+/", s[0]))
# print(s[0].replace(re.findall("/.+/", s[0])[0], ""))
# lst_af.append(s[0].replace(re.findall("/.+/", s[0])[0], ""))
# for i in range(1, len(s)):
#     if s[i][0] == "=":
#         s[i] = s[i].replace("=", "Ví dụ: ", 1)
#         s[i] = s[i].replace("+", " =")
#     elif s[i][0] == "!":
#         s[i] = s[i].replace("!", "Cụm từ: ", 1)
# lst_af.append("\n".join(s[1:]))
# lst_af.append(re.findall("/.+/", s[0])[0])
# print(lst_af)