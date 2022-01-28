import React, { useRef, useEffect, useCallback, useState } from "react";

import "./ChessBoard.css";

export const ChessBoard = () => {
  const ROW = 10,
    COL = 9,
    innerBoardX = 90,
    innerBoardY = 40,
    boxSize = 50;

  const COLOR = {
    RED: "red",
    BLACK: "black",
  };

  const [rows, setRows] = useState([]);
  const [cols, setCols] = useState([]);
  const [selectedPiece, setSelectedPiece] = useState({
    color: "",
    name: "",
    row: "",
    col: "",
  });
  const [player, setPlayer] = useState(COLOR.RED);

  const pieces = {
    black: {
      general: "將",
      advisor: "士",
      elephant: "象",
      horse: "馬",
      chariot: "車",
      cannon: "砲",
      soldier: "卒",
    },
    red: {
      general: "帥",
      advisor: "仕",
      elephant: "相",
      horse: "傌",
      chariot: "俥",
      cannon: "炮",
      soldier: "兵",
    },
  };

  const canvasRef = useRef(null);

  // eslint-disable-next-line react-hooks/exhaustive-deps
  const drawBoard = useCallback((ctx) => {
    ctx.beginPath();
    ctx.fillStyle = "#FCAF3E";
    ctx.fillRect(
      innerBoardX - 45,
      innerBoardY - 45,
      90 + boxSize * (COL - 1),
      90 + boxSize * (ROW - 1)
    );

    ctx.lineWidth = 2;
    ctx.beginPath();
    // vertical line
    for (let i = 0, x = innerBoardX; i < COL; i++) {
      if (i === 0 || i === 8) {
        drawLine(ctx, x, innerBoardY, 0, boxSize * (ROW - 1));
      } else {
        drawLine(ctx, x, innerBoardY, 0, boxSize * 4);
        drawLine(ctx, x, innerBoardY + boxSize * 5, 0, boxSize * 4);
      }
      x += boxSize;
    }

    // horizontal line
    for (let i = 0, y = innerBoardY; i < ROW; i++) {
      drawLine(ctx, innerBoardX, y, boxSize * (COL - 1), 0);
      y += boxSize;
    }

    drawCrosses(ctx);
    drawBorder(ctx);
    drawRiver(ctx);
    drawPoints(ctx);
  });

  const drawLine = (ctx, x, y, xLength, yLength) => {
    ctx.moveTo(x, y);
    ctx.lineTo(x + xLength, y + yLength);
    ctx.stroke();
  };

  const drawPoint = (ctx, x, y) => {
    drawLeftPoint(ctx, x, y);
    drawRightPoint(ctx, x, y);
  };

  const drawLeftPoint = (ctx, x, y) => {
    drawLine(ctx, x - 5, y - 5, 0, -10);
    drawLine(ctx, x - 5, y - 5, -10, 0);
    drawLine(ctx, x - 5, y + 5, 0, 10);
    drawLine(ctx, x - 5, y + 5, -10, 0);
  };

  const drawRightPoint = (ctx, x, y) => {
    drawLine(ctx, x + 5, y - 5, 0, -10);
    drawLine(ctx, x + 5, y - 5, 10, 0);
    drawLine(ctx, x + 5, y + 5, 0, 10);
    drawLine(ctx, x + 5, y + 5, 10, 0);
  };

  const drawCrosses = (ctx) => {
    drawLine(
      ctx,
      innerBoardX + boxSize * 3,
      innerBoardY,
      boxSize * 2,
      boxSize * 2
    );
    drawLine(
      ctx,
      innerBoardX + boxSize * 5,
      innerBoardY,
      boxSize * -2,
      boxSize * 2
    );
    drawLine(
      ctx,
      innerBoardX + boxSize * 3,
      innerBoardY + boxSize * 9,
      boxSize * 2,
      boxSize * -2
    );
    drawLine(
      ctx,
      innerBoardX + boxSize * 5,
      innerBoardY + boxSize * 9,
      boxSize * -2,
      boxSize * -2
    );
  };

  const drawBorder = (ctx) => {
    drawLine(ctx, innerBoardX - 5, innerBoardY - 5, 0, boxSize * 9 + 10);
    drawLine(
      ctx,
      innerBoardX - 5,
      innerBoardY + 5 + boxSize * 9,
      boxSize * 8 + 10,
      0
    );

    drawLine(ctx, innerBoardX - 5, innerBoardY - 5, boxSize * 8 + 10, 0);
    drawLine(
      ctx,
      innerBoardX + 5 + boxSize * 8,
      innerBoardY - 5,
      0,
      boxSize * 9 + 10
    );
  };

  const drawRiver = (ctx) => {
    ctx.font = "28px serif";
    ctx.strokeText(
      "楚",
      innerBoardX + boxSize + 10,
      innerBoardY + boxSize * 5 - 15
    );
    ctx.strokeText(
      "河",
      innerBoardX + boxSize * 2 + 10,
      innerBoardY + boxSize * 5 - 15
    );
    ctx.strokeText(
      "漢",
      innerBoardX + boxSize * 5 + 10,
      innerBoardY + boxSize * 5 - 15
    );
    ctx.strokeText(
      "界",
      innerBoardX + boxSize * 6 + 10,
      innerBoardY + boxSize * 5 - 15
    );
  };

  const drawPoints = (ctx) => {
    // cannon
    drawPoint(ctx, innerBoardX + boxSize, innerBoardY + boxSize * 2);
    drawPoint(ctx, innerBoardX + boxSize * 7, innerBoardY + boxSize * 2);
    drawPoint(ctx, innerBoardX + boxSize, innerBoardY + boxSize * 7);
    drawPoint(ctx, innerBoardX + boxSize * 7, innerBoardY + boxSize * 7);

    // soldier
    drawRightPoint(ctx, innerBoardX, innerBoardY + boxSize * 3);
    drawPoint(ctx, innerBoardX + boxSize * 2, innerBoardY + boxSize * 3);
    drawPoint(ctx, innerBoardX + boxSize * 4, innerBoardY + boxSize * 3);
    drawPoint(ctx, innerBoardX + boxSize * 6, innerBoardY + boxSize * 3);
    drawLeftPoint(ctx, innerBoardX + boxSize * 8, innerBoardY + boxSize * 3);

    drawRightPoint(ctx, innerBoardX, innerBoardY + boxSize * 6);
    drawPoint(ctx, innerBoardX + boxSize * 2, innerBoardY + boxSize * 6);
    drawPoint(ctx, innerBoardX + boxSize * 4, innerBoardY + boxSize * 6);
    drawPoint(ctx, innerBoardX + boxSize * 6, innerBoardY + boxSize * 6);
    drawLeftPoint(ctx, innerBoardX + boxSize * 8, innerBoardY + boxSize * 6);
  };

  const initializeBoard = () => {
    fetch("https://localhost:44304/api/game/InitGame", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
    }).then(async (res) => {
      for (let i = 0; i < 2; i++) {
        let color, piece;
        if (i === 0) {
          piece = pieces.red;
          color = COLOR.RED;
        } else {
          piece = pieces.black;
          color = COLOR.BLACK;
        }

        drawPiece(color, piece.general, 4, i === 0 ? 0 : 9);
        drawPiece(color, piece.advisor, 3, i === 0 ? 0 : 9);
        drawPiece(color, piece.advisor, 5, i === 0 ? 0 : 9);
        drawPiece(color, piece.elephant, 2, i === 0 ? 0 : 9);
        drawPiece(color, piece.elephant, 6, i === 0 ? 0 : 9);
        drawPiece(color, piece.horse, 1, i === 0 ? 0 : 9);
        drawPiece(color, piece.horse, 7, i === 0 ? 0 : 9);
        drawPiece(color, piece.chariot, 0, i === 0 ? 0 : 9);
        drawPiece(color, piece.chariot, 8, i === 0 ? 0 : 9);
        drawPiece(color, piece.cannon, 1, i === 0 ? 2 : 7);
        drawPiece(color, piece.cannon, 7, i === 0 ? 2 : 7);
      }

      for (let i = 0; i <= 8; i += 2) {
        drawPiece(COLOR.RED, pieces.red.soldier, i, 3);
        drawPiece(COLOR.BLACK, pieces.black.soldier, i, 6);
      }
    });
  };

  const drawPiece = (color, name, x, y) => {
    var box = document.getElementById("box-" + x + "-" + y);

    box.classList.add(color);
    box.classList.remove(color === COLOR.BLACK ? COLOR.RED : COLOR.BLACK);
    box.classList.remove("hide");
    box.classList.remove("selected");

    box.innerHTML = name;
  };

  const deletePiece = (x, y) => {
    clearPieceInfo(document.getElementById("box-" + x + "-" + y));
  };

  const clearPieceInfo = (piece) => {
    piece.classList.remove(COLOR.BLACK);
    piece.classList.remove(COLOR.RED);

    piece.classList.remove("selected");
    piece.classList.add("hide");
    piece.innerHTML = "";
  };

  useEffect(() => {
    const rows = [];
    for (let i = 0; i < ROW; i++) rows.push(i);
    setRows(rows);

    const cols = [];
    for (let i = 0; i < COL; i++) cols.push(i);
    setCols(cols);

    const canvas = canvasRef.current;
    const context = canvas.getContext("2d");

    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;

    drawBoard(context);
    setTimeout(newGame, 500);
  }, []);

  const selectPiece = (target) => {
    // remove selected piece
    if (target.classList.contains("selected")) {
      target.classList.remove("selected");
      setSelectedPiece({
        color: "",
        name: "",
        row: "",
        col: "",
      });
      return;
    }

    const box = target.id.split("-");
    if (target.classList.contains(player)) {
      if (selectedPiece.col && selectedPiece.row) {
        const prevPiece = document.getElementById(
          "box-" + selectedPiece.col + "-" + selectedPiece.row
        );
        prevPiece.classList.remove("selected");
      }

      target.classList.add("selected");
      setSelectedPiece({
        color: player,
        name: target.innerHTML,
        row: box[2],
        col: box[1],
      });

      return;
    }

    // call function to backend, move if valid
    if (selectedPiece.color) {
      const request = {
        from: {
          row: selectedPiece.row,
          col: selectedPiece.col,
        },
        to: {
          row: box[2],
          col: box[1],
        },
      };

      fetch("https://localhost:44304/api/game/Move", {
        method: "POST",
        body: JSON.stringify(request),
        headers: {
          "Content-Type": "application/json",
        },
      }).then(async (res) => {
        const data = await res.json();
        if (data.canMove) {
          deletePiece(selectedPiece.col, selectedPiece.row);
          drawPiece(selectedPiece.color, selectedPiece.name, box[1], box[2]);

          setSelectedPiece({
            color: "",
            name: "",
            x: "",
            y: "",
          });

          if (data.isEnd) {
            console.log(player + " Win !");
          } else {
            if (data.isCheck) {
              console.log("Check!");
            }

            setPlayer(player === COLOR.RED ? COLOR.BLACK : COLOR.RED);
          }
        }
      });
    }
  };

  const newGame = () => {
    var pieces = document.getElementsByClassName("piece-box");

    for (let piece of pieces) {
      clearPieceInfo(piece);
    }
    initializeBoard();

    setPlayer(COLOR.RED);
    setSelectedPiece({
      color: "",
      name: "",
      x: "",
      y: "",
    });
  };

  return (
    <div>
      <canvas id="chinese-chess-board-canvas" ref={canvasRef} />
      <div id="chinese-chess-board">
        {rows.map((row) => {
          return (
            <div id="pieces-row" key={row}>
              {cols.map((col) => {
                return (
                  <div
                    className="piece-box hide"
                    key={col + "-" + row}
                    id={"box-" + col + "-" + row}
                    onClick={(e) => selectPiece(e.target)}
                  ></div>
                );
              })}
            </div>
          );
        })}
      </div>
      <div id="buttons-container">
        <button type="button" id="new-game-btn" onClick={newGame}>
          New Game
        </button>
      </div>
    </div>
  );
};
