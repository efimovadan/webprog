import { Box, Grid, Text } from "grommet";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { PairRecord } from "../objects/PairRecord";
import { PairsInfo } from "../objects/PairsInfo";
import { parisRepository } from "../repositories/ParisRepository";
import "../style.css";

export const PairingRecordsPage = (props: any) => {
  const [records, setRecords] = useState<PairsInfo>();

  useEffect(() => {
    parisRepository.getPairsRecords().then((data) => {
      setRecords(data);
    });
  }, []);
  return (
    <Box fill align="center" justify="center">
      <Grid
        margin="medium"
        columns={{
          count: 5,
          size: "auto",
        }}
        gap="small"
      >
        <>
          <Text className="text">{"#"}</Text>
          <Text className="text">{"Собеседник"}</Text>
          <Text className="text">{"Типа"}</Text>
          <Text className="text">{"Рейтинг"}</Text>
          <Text className="text">{"Комментарий"}</Text>
        </>
        {records?.list.map((record: PairRecord, index: number) => (
          <>
            <Text className="text">{index}</Text>
            <Text className="text">
              <Link
                to={"/profile/" + record.pairedUserId}
                className="text text-green"
              >
                {record.pairedUserId}
              </Link>
            </Text>
            <Text className="text">{record.type}</Text>
            <Text className="text">{record.rating}</Text>
            <Text className="text">{record.ratingDescription}</Text>
          </>
        ))}
      </Grid>
    </Box>
  );
};
