USE JustInMind;

GRANT ALL ON Tasks TO Victor;

GRANT SELECT ON Tasks TO PUBLIC;

GRANT DELETE ON Users TO Victor;

DENY All ON Comments TO Victor;

REVOKE ALL ON Histories TO PUBLIC;
